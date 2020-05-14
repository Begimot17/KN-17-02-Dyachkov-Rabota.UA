using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach_Web_Dyachkov.Models
{
    public class AnnouncementViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public CategoryViewModel Category { get; set; }

        public UserViewModel User { get; set; }
    }
}