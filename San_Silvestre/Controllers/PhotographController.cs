using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace San_Silvestre.Controllers
{
    public class PhotographController : Controller
    {
        // GET: Photograph
        public ActionResult PhotoView()
        {
            return View();
        }
    }
}