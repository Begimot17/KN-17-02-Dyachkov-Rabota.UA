using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Repository
{
    public class RegionRepository:BaseRepository
    {
        public void Create(Region model)
        {
            WithContext(context =>
            {
                context.Regions.Add(model);
                context.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            WithContext(context =>
            {
                var category = context.Regions.Single(x => x.Id.Equals(id));

                context.Regions.Remove(category);

                context.SaveChanges();
            });
        }


        public void Update(Region model)
        {
            WithContext(context =>
            {
                var category = context.Regions.Single(x => x.Id.Equals(model.Id));

                category.Id = model.Id;
                category.Name = model.Name;
                context.SaveChanges();
            });
        }
        public IEnumerable<Region> GetCategories()
        {
            var result = new Region[] { };

            WithContext(context =>
            {
                result = context.Regions.ToArray()
                .Select(x => new Region
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray();
            });

            return result;
        }
        public Region GetCategory(string name)
        {
            Region user = null;
            WithContext(context =>
            {
                user = context.Regions.Single(x => x.Name.Equals(name));
            });

            return user;
        }
        public Region GetCategory(int id)
        {
            Region user = null;
            WithContext(context =>
            {
                user = context.Regions.Single(x => x.Id.Equals(id));
            });

            return user;
        }
    }
}
