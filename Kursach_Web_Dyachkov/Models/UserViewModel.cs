using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kursach_Web_Dyachkov.Models
{
    public class UserViewModel:BaseViewModel
    {
        public string Surname { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }

        public string NumberPhone { get; set; }

        public string Password { get; set; }
        public string Summary { get; set; }
        public int ProfessionId { get; set; }
        public int RegionId { get; set; }

        public  ProfessionViewModel Profession { get; set; }
        public  RegionViewModel Region { get; set; }
    }
}