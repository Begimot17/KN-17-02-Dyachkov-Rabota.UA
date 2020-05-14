using AutoMapper;
using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using Kursach_Web_Dyachkov.Dal.CodeFirst.Repository;
using Kursach_Web_Dyachkov.Infrastructure;
using Kursach_Web_Dyachkov.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Kursach_Web_Dyachkov.Controllers
{
    public class AdminController : Controller
    {
        UserRepository userRepository = new UserRepository();
        RegionRepository regionRepository = new RegionRepository();
        ProfessionRepository professionRepository = new ProfessionRepository();
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        public ActionResult Create()
        {
            var regions = new Dictionary<string, int>();
            regionRepository.GetCategories().ForEach(x => regions.Add(x.Name, x.Id));
            ViewData["Regions"] = new SelectList(regions, "Value", "Key");
            var prof = new Dictionary<string, int>();
            professionRepository.GetCategories().ForEach(x => prof.Add(x.Name, x.Id));
            ViewData["Professions"] = new SelectList(prof, "Value", "Key");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, User>()));
            var announ = mapper.Map<User>(model);
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Email};
                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    userRepository.Create(announ);
                    return RedirectToAction("Index","Work");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}