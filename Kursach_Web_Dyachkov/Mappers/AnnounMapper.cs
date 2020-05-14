using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using Kursach_Web_Dyachkov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach_Web_Dyachkov.Mappers
{
    public static class AnnounMapper
    {
        public static Announcement ToEntity(this AnnouncementViewModel model) =>
            new Announcement
            {
                Id = model.Id,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                UserId = model.UserId
            };
        public static AnnouncementViewModel ToView(this Announcement model) =>
            new AnnouncementViewModel
            {
                Id = model.Id,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                UserId = model.UserId,
                User=model.User.ToView(),
                Category=new CategoryViewModel
                {
                    Id=model.CategoryId,
                    Name=model.Category.Name
                }
            };
        public static List<AnnouncementViewModel> ToView(this List<Announcement> model) =>
            new List<AnnouncementViewModel>(model.Select(x=>x.ToView()));
    }
}