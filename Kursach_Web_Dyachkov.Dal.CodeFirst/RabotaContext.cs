using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Web_Dyachkov.Dal.CodeFirst
{
    public class RabotaContext: DbContext
    {
        public RabotaContext()
                   : base("Data Source=COMPUTER;Initial Catalog=Kursach_Web_Dyachkov;Integrated Security=True;MultipleActiveResultSets=True")
        {
        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Profession> Professions { get; set; }


    }
}
