using AutoMapper;
using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using Kursach_Web_Dyachkov.Dal.CodeFirst.Repository;
using Kursach_Web_Dyachkov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kursach_Web_Dyachkov.Controllers
{
    public class ProfessionController : Controller
    {
        ProfessionRepository professionRepository = new ProfessionRepository();

        public ActionResult Index()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Profession, ProfessionViewModel>()));
            var announs = mapper.Map<List<ProfessionViewModel>>(professionRepository.GetCategories());
            return View(announs);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegionViewModel model)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Profession, ProfessionViewModel>()));
            var announ = mapper.Map<Profession>(model);
            professionRepository.Create(announ);
            return Redirect("/Home/Index");
        }
        [Authorize]
        public ActionResult Edit(int Id)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Profession, ProfessionViewModel>()));
            var announ = mapper.Map<ProfessionViewModel>(professionRepository.GetCategory(Id));
            return View(announ);
        }
        [HttpPost]
        public ActionResult Edit(ProfessionViewModel std)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Profession, ProfessionViewModel>()));
            var announ = mapper.Map<Profession>(std);
            professionRepository.Update(announ);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int Id)
        {
            professionRepository.Delete(Id);
            return Redirect("/Profession/Index");
        }
    }
}