using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanSil.BLL.Position.Interface;
using SanSil.BLL.Position.Models;
using SanSil.BLL.Category.Models;
using SanSil.BLL.Category.Interface;
using SanSil.DAL;
using System.Globalization;

namespace SanSil.BLL.Position.Implementation
{
    public class PositionManager : IPositionManager
    {
        public List<Models.Position> GetAllRunners(int vCategoryId)
        {
            using (var db = new SanSilvestreEntities())
            {
                var vCategoryData = db.Competition_Category.FirstOrDefault(x => x.Id == vCategoryId );
                if (vCategoryData != null)
                {

                    var data = db.Competition_Runner
                        .Include("Runner")
                        .Where(z => z.CompetitionId == vCategoryData.CompetitionId &&
                            z.CategoryId == vCategoryData.CategoryId &&
                            z.GenderId == vCategoryData.GenderId)
                        .OrderBy(y => y.PositionId)
                        .Select(x => new Models.Position
                        {
                            Id = x.Id,
                            CompetitionId = x.CompetitionId,
                            PositionId = x.PositionId,
                            GeneralPosition = x.GeneralPosition,
                            Dorsal = x.Dorsal,
                            RunnerId = x.RunnerId,
                            RunnerName = x.Runner.Name,
                            RunnerSurName = x.Runner.SurName,
                            Club = x.Runner.Club,
                            Elapsed_Time = x.Elapsed_Time,
                            CategoryId = x.CategoryId,
                            GenderId = x.GenderId
                        }).ToList();

                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public Dictionary<string, string> GetGenderDir()
        {
            using (var db = new SanSilvestreEntities())
            {
                return db.Gender.OrderBy(x => x.Id).ToDictionary(x => x.Id.ToString(CultureInfo.InvariantCulture), x => x.Name);
            }
        }

        public Dictionary<string, string> GetCategoryDescriptions()
        {
            using (var db = new SanSilvestreEntities())
            {
                return db.Competition_Category.OrderBy(x => x.Id).ToDictionary(x => x.Id.ToString(CultureInfo.InvariantCulture), x => x.Description);
            }
        }

        public List<Models.MyCategoriesDescriptions> GetAllCategories()
        {
            using (var db = new SanSilvestreEntities())
            {
                var data = db.Competition_Category.Select(x => new Models.MyCategoriesDescriptions
                {
                    Id = x.Id,
                    Description = x.Description
                }).ToList();
                return data;
            }
        }

    }
}
