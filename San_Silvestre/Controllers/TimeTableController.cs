using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace San_Silvestre.Controllers
{
    public class TimeTableController : Controller
    {
        // GET: TimeTable
        public ActionResult TimeTableView()
        {
            return View();
        }
    }
}