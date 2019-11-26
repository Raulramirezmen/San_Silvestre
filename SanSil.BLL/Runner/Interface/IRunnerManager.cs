using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSil.BLL.Runner.Interface
{
    public interface IRunnerManager
    {
        Models.Runner GetRunner(int id);
        Models.Runner GetRunner(string  pDNI);
        Dictionary<string, string> GetGenderDir();
        Dictionary<string, string> GetDocumentTypeDir();
        int SaveRunner(Models.Runner runner);
        void RemoveRunner(int id);
    }
}
