using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using Kursach_Web_Dyachkov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach_Web_Dyachkov.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToView(this User model) =>
            new UserViewModel
            {
                Id = model.Id,
                Surname = model.Surname,
                Name = model.Name,
                Age = model.Age,
                Summary= model.Summary,
                Email = model.Email,
                NumberPhone = model.NumberPhone,
                ProfessionId = model.ProfessionId,
                RegionId = model.RegionId,
                Region=new RegionViewModel
                {
                    Id=model.Region.Id,
                    Name= model.Region.Name
                },
                 Profession= new ProfessionViewModel
                 {
                    Id = model.Profession.Id,
                    Name = model.Profession.Name
                }
            };
        public static List<UserViewModel> ToView(this List<User> model) =>
            model.Select(x => x.ToView()).ToList();

        public static User ToEntity(this UserViewModel model) =>
            new User
            {
                Id = model.Id,
                Surname = model.Surname,
                Name = model.Name,
                Age = model.Age,
                Summary = model.Summary,
                Email = model.Email,
                NumberPhone = model.NumberPhone,
                ProfessionId = model.ProfessionId,
                RegionId = model.RegionId,
            };

    }
}