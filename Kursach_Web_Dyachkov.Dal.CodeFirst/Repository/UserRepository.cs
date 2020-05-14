using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Repository
{
    public class UserRepository : BaseRepository
    {
        public void Create(User model)
        {
            WithContext(context =>
            {
                context.Users.Add(model);
                context.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(id));

                context.Users.Remove(user);

                context.SaveChanges();
            });
        }


        public void Update(User model)
        {
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(model.Id));
                user.Id = model.Id;
                user.Surname = model.Surname;
                user.Name = model.Name;
                user.Age = model.Age;
                user.RegionId = model.RegionId;
                user.ProfessionId = model.ProfessionId;
                user.Summary = model.Summary;
                user.Password = model.Password;
                user.Email = model.Email;
                context.SaveChanges();
            });
        }
        public IEnumerable<User> GetAnnouncements()
        {
            var result = new User[] { };
       
            WithContext(context =>
            {
                result = context.Users.Include(x=>x.Profession).Include(x => x.Region).ToArray();
            });

            return result;
        }
        public User GetUser(string email)
        {
            User user = null;
            WithContext(context =>
            {
                user = context.Users.Include(q=>q.Region).Include(q => q.Profession).First(x => x.Email.Equals(email));
            });

            return user;
        }
        public User GetUser(int id)
        {
            User user = null;
            WithContext(context =>
            {
                user = context.Users.Include(q => q.Region).Include(q => q.Profession).First(x => x.Id.Equals(id));
            });

            return user;
        }
    }
}
