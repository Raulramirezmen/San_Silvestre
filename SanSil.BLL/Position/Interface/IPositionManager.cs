using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSil.BLL.Position.Interface
{
    public interface IPositionManager
    {
        List<Models.Position> GetAllRunners(int UniqueCategoryId);
        Dictionary<string, string> GetGenderDir();
        Dictionary<string, string> GetCategoryDescriptions();
        List<Models.MyCategoriesDescriptions> GetAllCategories();
        //List<SanSil.BLL.Category.Models.Categories> GetCategoryDescriptions2();
    }
}
