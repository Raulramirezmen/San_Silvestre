using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanSil.BLL.Award.Interface;

namespace San_Silvestre.Controllers
{
    public class AwardController : Controller
    {
        public readonly IAwardManager _AwardManager;

        public AwardController(IAwardManager AwardManager) : base()
        {
             _AwardManager = AwardManager;
        }
        // GET: Award
        public ActionResult AwardView()
        {
            return View();
        }
    }
}