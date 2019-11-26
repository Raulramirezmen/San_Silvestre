using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSil.BLL.Category.Interface
{
    public interface ICategoryManager
    {
        Models.Categories GetCategoryData(int Id);
        IEnumerable<Models.Categories> GetAllCategories();
        void AddCategory(string CatName);
        void DeleteCategory(int Id);
        void EditCategory(int Id, string Name);
    }
}
