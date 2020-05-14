using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Repository
{
    public class ProfessionRepository: BaseRepository
    {
        public void Create(Profession model)
        {
            WithContext(context =>
            {
                context.Professions.Add(model);
                context.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            WithContext(context =>
            {
                var category = context.Professions.Single(x => x.Id.Equals(id));

                context.Professions.Remove(category);

                context.SaveChanges();
            });
        }


        public void Update(Profession model)
        {
            WithContext(context =>
            {
                var category = context.Professions.Single(x => x.Id.Equals(model.Id));

                category.Id = model.Id;
                category.Name = model.Name;
                context.SaveChanges();
            });
        }
        public IEnumerable<Profession> GetCategories()
        {
            var result = new Profession[] { };

            WithContext(context =>
            {
                result = context.Professions.ToArray()
                .Select(x => new Profession
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray();
            });

            return result;
        }
        public Profession GetCategory(string name)
        {
            Profession user = null;
            WithContext(context =>
            {
                user = context.Professions.Single(x => x.Name.Equals(name));
            });

            return user;
        }
        public Profession GetCategory(int id)
        {
            Profession user = null;
            WithContext(context =>
            {
                user = context.Professions.Single(x => x.Id.Equals(id));
            });

            return user;
        }
    }
}
