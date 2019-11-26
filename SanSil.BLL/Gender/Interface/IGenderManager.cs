using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSil.BLL.Gender.Interface
{
    public interface IGenderManager
    {
        Models.Gender GetGenderData(string Id);
        IEnumerable<Models.Gender> GetAllGenders();
        void AddGender(string Id);
        void DeleteGender(string Id);
        //void EditGender(string Id);

    }
}
