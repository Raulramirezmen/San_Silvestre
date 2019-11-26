using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanSil.BLL.Gender.Interface;
using SanSil.BLL.Gender.Models;
using SanSil.DAL;

namespace SanSil.BLL.Gender.Implementation
{
    public class GenderManager : IGenderManager
    {

        public Models.Gender GetGenderData(string Id)
        {
            using (var db = new SanSilvestreEntities())
            {
                var gender = db.Gender.FirstOrDefault(x => x.Id == Id);
                if (gender != null)
                {
                    return new Models.Gender
                    {
                        Id = gender.Id,
                        Name = gender.Name,
                    };
                }
                return null;
            }

        }

        public IEnumerable<Models.Gender> GetAllGenders()
        {
            using (var db = new SanSilvestreEntities())
            {
                var data = db.Gender.Select(x => new SanSil.BLL.Gender.Models.Gender
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray();
                return data;
            }
        }

        public void AddGender(string Id)
        {
            using (var db = new SanSilvestreEntities())
            {
                var gender = GetGenderData(Id);
                db.Gender.Add(new DAL.Gender
                {
                    Id = gender.Id,
                    Name = gender.Name
                });
                db.SaveChanges();
            }
        }

        public void DeleteGender(string Id)
        {
            using (var db = new SanSilvestreEntities())
            {
                db.Gender.Remove(db.Gender.First(x => x.Id.Equals(Id)));
                db.SaveChanges();
            }
        }

        //public void EditGender(string Id)
        //{
        //    using (var db = new SanSilvestreEntities())
        //    {
        //        var gen = db.Gender.First(x => x.Id.Equals(Id));
        //        var genModel = new DAL.Gender();
        //        gen.Name = genModel.Name;
        //        db.SaveChanges();
        //    }
        //}
    }
}
