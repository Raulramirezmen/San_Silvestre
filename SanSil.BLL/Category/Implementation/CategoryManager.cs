using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanSil.DAL;
using System.Globalization;
using SanSil.BLL.Category.Interface;

namespace SanSil.BLL.Category.Implementation
{
    public class CategoryManager : ICategoryManager
    {

        public Models.Categories GetCategoryData(int Id)
        {
            using (var db = new SanSilvestreEntities())
            {
                var Category = db.Category.FirstOrDefault(x => x.Id == Id);
                if (Category != null)
                {
                    return new Models.Categories
                    {
                        Id = Category.Id,
                        Name = Category.Name,
                    };
                }
                return null;
            }

        }

        public IEnumerable<Models.Categories> GetAllCategories()
        {
            using (var db = new SanSilvestreEntities())
            {
                var data = db.Category.Select(x => new SanSil.BLL.Category.Models.Categories
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray();
                return data;
            }
        }

        public void AddCategory(string CatName)
        {
            using (var db = new SanSilvestreEntities())
            {
                db.Category.Add(new DAL.Category
                {
                    Id = 0,
                    Name = CatName
                });
                db.SaveChanges();
            }
        }

        public void DeleteCategory(int Id)
        {
            using (var db = new SanSilvestreEntities())
            {
                db.Category.Remove(db.Category.First(x => x.Id.Equals(Id)));
                db.SaveChanges();
            }
        }

        public void EditCategory(int Id, string Name)
        {
            using (var db = new SanSilvestreEntities())
            {
                var Cat = db.Category.First(x => x.Id.Equals(Id));
                Cat.Name = Name;
                db.SaveChanges();
            }
        }

    }
}
