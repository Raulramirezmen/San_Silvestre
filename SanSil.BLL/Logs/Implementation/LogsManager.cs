using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SanSil.BLL.Logs.Interface;
using SanSil.DAL;

namespace SanSil.BLL.Logs.Implementation
{
    public class LogsManager: ILogsManager
    {
        public List<DAL.Log> GetLogs(DateTime startDateTime, DateTime endDateTime)
        {
            using (var db = new SanSilvestreEntities())
            {
                return db.Log.Where(x => x.Date >= startDateTime && x.Date <= endDateTime).ToList();
            }
        }
    }
}
