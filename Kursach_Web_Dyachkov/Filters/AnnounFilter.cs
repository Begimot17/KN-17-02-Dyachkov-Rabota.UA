using Kursach_Web_Dyachkov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach_Web_Dyachkov.Filters
{
    public static class AnnounFilter
    {
        public static List<AnnouncementViewModel> CategoryFilter(this List<AnnouncementViewModel> model, string category) =>
            model.Where(x => x.Category.Name == category).ToList();
        public static List<AnnouncementViewModel> PriceFilter(this List<AnnouncementViewModel> model, int min, int max) =>
            model.Where(x => x.Price <= max && x.Price >= min).ToList();

    }
}