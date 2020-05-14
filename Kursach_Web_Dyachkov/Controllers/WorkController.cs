using Kursach_Web_Dyachkov.Models;
using Kursach_Web_Dyachkov.Dal.CodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kursach_Web_Dyachkov.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using AutoMapper;
using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using Kursach_Web_Dyachkov.Mappers;
using Microsoft.Ajax.Utilities;
using Kursach_Web_Dyachkov.Filters;

namespace Kursach_Web_Dyachkov.Controllers
{
    public class WorkController : Controller
    {
        AnnounRepository announRepository = new AnnounRepository();
        UserRepository userRepository = new UserRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult MyProfile()
        {
            var user = userRepository.GetUser(GetAutoUser().UserName).ToView();
            return View(user);
        }
        public ActionResult Profile(int id)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<User, UserViewModel>()));
            var announs = mapper.Map<UserViewModel>(userRepository.GetUser(id));
            return View(userRepository.GetUser(id));
        }
        public ActionResult Index()
        {
            var announs = announRepository.GetAnnouncements().ToList().ToView();
            return View(announs);

        }
        [HttpPost]
        public ActionResult Index(string category)
        {
            var announs = announRepository.GetAnnouncements().ToList().ToView();
            if (category!=null)
            {
                announs = announs.CategoryFilter(category);
            }
            return View(announs);

        }
        [Authorize]
        public ActionResult MyAnnoun()
        {
            var an = announRepository.GetAnnouncements();
            var email = GetAutoUser().UserName;
            var anwhere = an.Where(x => x.User.Email == email).ToList();
            return View(anwhere.ToView());
        }
        [Authorize]
        public ActionResult Create()
        {
            var regions = new Dictionary<string, int>();
            categoryRepository.GetCategories().ForEach(x => regions.Add(x.Name, x.Id));
            ViewData["Categories"] = new SelectList(regions, "Value", "Key");
            return View();
        }
        [HttpPost]
        public ActionResult Create(AnnouncementViewModel model)
        {

            model.UserId = userRepository.GetUser(GetAutoUser().UserName).Id;
            var announ = model.ToEntity();
            announRepository.Create(announ);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Edit()
        {
            return View();
        }

        [Authorize]
        public ActionResult Details(int Id)
        {
            var an = announRepository.GetAnnouncement(Id);
            return View(an.ToView());
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(announRepository.GetAnnouncement(id).ToView());
        }
        [HttpPost]
        public ActionResult Delete(AnnouncementViewModel model)
        {
            announRepository.Delete(model.Id);
            return RedirectToAction("MyAnnoun");
        }
        public AppUser GetAutoUser() =>
             UserManager.Users.First(x => x.UserName == HttpContext.User.Identity.Name);

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}