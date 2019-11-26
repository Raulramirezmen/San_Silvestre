using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SanSil.DAL;
using SanSil.BLL.Gender.Interface;
using SanSil.BLL.Gender.Models;
using San_Silvestre.Models;

namespace San_Silvestre.Controllers
{
    public class GenderController : Controller
    {
        public readonly IGenderManager _genderManager;

        public GenderController( IGenderManager genderManager) : base()
        {
             _genderManager = genderManager;
        }

        // GET: Genders
        public ActionResult Index()
        {
            var Genders = _genderManager.GetAllGenders();
            var genderModels = Genders.Select(x => new GenderModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return View(genderModels);
        }

        //[OutputCache(Duration = 0)]
        public PartialViewResult RefreshGenderData()
        {
            var genders = _genderManager.GetAllGenders();
            var genderModels = genders.Select(x => new GenderModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return PartialView("GenderDataGrid", genderModels);
        }

        [HttpPost]
        public JsonResult DeleteGender(string genId)
        {
            try
            {
                _genderManager.DeleteGender(genId);
                return Json(new GenericOutput { Status = true, Message = "Genero ha sido borrado." });
            }
            catch (Exception ex)
            {
                //Logger.Error(ex);
                return Json(new GenericOutput { Status = false, Message = "Error ocurrido cuando borraba el Género." });
            }
        }

        [HttpPost]
        public JsonResult AddNewGender(string genId)
        {
            try
            {
                if (_genderManager.GetGenderData(genId) != null)
                    return Json(new GenericOutput { Status = false, Message = "Genero ya existe." });
                _genderManager.AddGender(genId);
                return Json(new GenericOutput { Status = true, Message = "Genero ha sido añadido." });
            }
            catch (Exception ex)
            {
                //Logger.Error(ex);
                return Json(new GenericOutput { Status = false, Message = "Error ocurrido mientras añadia un Género." });
            }
        }

        //[HttpPost]
        //public JsonResult UpdateGenderData(string genId)
        //{
        //    try
        //    {
        //        _genderManager.EditGender(genId);
        //        return Json(new GenericOutput { Status = true, Message = "Employee data has been updated." });
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logger.Error(ex);
        //        return Json(new GenericOutput { Status = false, Message = "Error occured while updating employee data." });
        //    }
        //}
    }
}
