using Kursach_Web_Dyachkov.Dal.CodeFirst.Repository;
using Kursach_Web_Dyachkov.Mappers;
using Kursach_Web_Dyachkov.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kursach_Web_Dyachkov.Controllers
{
    public class UsersController : Controller
    {
        UserRepository userRepository = new UserRepository();
        RegionRepository regionRepository = new RegionRepository();
        ProfessionRepository professionRepository = new ProfessionRepository();
        public ActionResult Index()
        {
            var users = userRepository.GetAnnouncements().ToList().ToView();
            return View(users);
        }
        public ActionResult Details(int id)
        {
            var users = userRepository.GetUser(id).ToView();
            return View(users);
        }
        [Authorize]
        public ActionResult Edit(int Id)
        {
            var regions = new Dictionary<string, int>();
            regionRepository.GetCategories().ForEach(x => regions.Add(x.Name, x.Id));
            ViewData["Regions"] = new SelectList(regions, "Value", "Key");
            var prof = new Dictionary<string, int>();
            professionRepository.GetCategories().ForEach(x => prof.Add(x.Name, x.Id));
            ViewData["Professions"] = new SelectList(prof, "Value", "Key");
            return View(userRepository.GetUser(Id).ToView());
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel std)
        {
            userRepository.Update(std.ToEntity());
            return RedirectToAction("Index");
        }
    }
}