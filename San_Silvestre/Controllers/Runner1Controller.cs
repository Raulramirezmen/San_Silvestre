using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace San_Silvestre.Controllers
{
    public class Runner1Controller : Controller
    {
        // GET: Runner1
        public ActionResult Index()
        {
            return View();
        }

        // GET: Runner1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Runner1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Runner1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Runner1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Runner1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Runner1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Runner1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
