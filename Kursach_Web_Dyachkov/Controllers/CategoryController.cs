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
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public ActionResult Index()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryViewModel>()));
            var announs = mapper.Map<List<CategoryViewModel>>(categoryRepository.GetCategories());
            return View(announs);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryViewModel>()));
            var announ = mapper.Map<Category>(model);
            categoryRepository.Create(announ);
            return Redirect("/Home/Index");
        }
        [Authorize]
        public ActionResult Edit(int Id)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryViewModel>()));
            var announ = mapper.Map<CategoryViewModel>(categoryRepository.GetCategory(Id));
            return View(announ);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel std)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryViewModel>()));
            var announ = mapper.Map<Category>(std);
            categoryRepository.Update(announ);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int Id)
        {
            categoryRepository.Delete(Id);
            return Redirect("/Category/Index");
        }
    }
}