using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Repository
{
    public class AnnounRepository : BaseRepository
    {
        public void Create(Announcement model)
        {
            WithContext(context =>
            {
                context.Announcements.Add(model);
                context.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            WithContext(context =>
            {
                var announcement = context.Announcements.Single(x => x.Id.Equals(id));

                context.Announcements.Remove(announcement);

                context.SaveChanges();
            });
        }


        public void Update(Announcement model)
        {
            WithContext(context =>
            {
                var announcement = context.Announcements.First(x => x.Id.Equals(model.Id));

                announcement.Id = model.Id;
                announcement.Name = model.Name;
                announcement.Price = model.Price;
                announcement.User = model.User;
                announcement.Category = model.Category;
                announcement.Description = model.Description;

                context.SaveChanges();
            });
        }
        public IEnumerable<Announcement> GetAnnouncements()
        {
            var result = new List<Announcement>();
            WithContext(context =>
            {
                result = context.Announcements.Include(x=>x.User).Include(w=>w.User.Region)
                .Include(w => w.User.Profession).Include(x => x.Category).ToList();
            });

            return result;
        }
        public Announcement GetAnnouncement(int id)
        {
            Announcement announcement = null;
            WithContext(context =>
            {
                announcement = context.Announcements.
                Include(y => y.User).Include(w => w.User.Region)
                .Include(w => w.User.Profession).Include(z => z.Category).First(x => x.Id.Equals(id));
            });

            return announcement;
        }
    }
}
