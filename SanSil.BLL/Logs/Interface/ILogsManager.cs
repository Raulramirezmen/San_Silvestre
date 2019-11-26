using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSil.BLL.Logs.Interface
{
    interface ILogsManager
    {
        List<DAL.Log> GetLogs(DateTime startDateTime, DateTime endDateTime);
    }
}
