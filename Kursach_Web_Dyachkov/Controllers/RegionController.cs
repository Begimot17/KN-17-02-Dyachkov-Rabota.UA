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
    public class RegionController : Controller
    {
        RegionRepository regionRepository = new RegionRepository();

        public ActionResult Index()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Region, RegionViewModel>()));
            var announs = mapper.Map<List<RegionViewModel>>(regionRepository.GetCategories());
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
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Region, RegionViewModel>()));
            var announ = mapper.Map<Region>(model);
            regionRepository.Create(announ);
            return Redirect("/Home/Index");
        }
        [Authorize]
        public ActionResult Edit(int Id)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Region, RegionViewModel>()));
            var announ = mapper.Map<RegionViewModel>(regionRepository.GetCategory(Id));
            return View(announ);
        }
        [HttpPost]
        public ActionResult Edit(Region std)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Region, RegionViewModel>()));
            var announ = mapper.Map<Region>(std);
            regionRepository.Update(announ);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int Id)
        {
            regionRepository.Delete(Id);
            return Redirect("/Region/Index");
        }
    }
}