using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Repository
{
    public class CategoryRepository:BaseRepository
    {
        public void Create(Category model)
        {
            WithContext(context =>
            {
                context.Categories.Add(model);
                context.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            WithContext(context =>
            {
                var category = context.Categories.Single(x => x.Id.Equals(id));

                context.Categories.Remove(category);

                context.SaveChanges();
            });
        }


        public void Update(Category model)
        {
            WithContext(context =>
            {
                var category = context.Categories.Single(x => x.Id.Equals(model.Id));

                category.Id = model.Id;
                category.Name = model.Name;
                context.SaveChanges();
            });
        }
        public IEnumerable<Category> GetCategories()
        {
            var result = new Category[] { };

            WithContext(context =>
            {
                result = context.Categories.ToArray()
                .Select(x => new Category
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray();
            });

            return result;
        }
        public Category GetCategory(string name)
        {
            Category user = null;
            WithContext(context =>
            {
                user = context.Categories.Single(x => x.Name.Equals(name));
            });

            return user;
        }
        public Category GetCategory(int id)
        {
            Category user = null;
            WithContext(context =>
            {
                user = context.Categories.Single(x => x.Id.Equals(id));
            });

            return user;
        }
    }
}
