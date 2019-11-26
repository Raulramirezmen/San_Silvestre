using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using San_Silvestre.Models;
using SanSil.BLL.Runner.Interface;
using SanSil.BLL.Runner.Models;

namespace San_Silvestre.Controllers
{
    public class RunnerController : Controller
    {

        public readonly IRunnerManager _runnerManager;

        public RunnerController(IRunnerManager runnerManager) : base()
        {
             _runnerManager = runnerManager;
        }

        // GET: Runner

        public ActionResult RunnerEdit()
        {
            var RunnerModels = new San_Silvestre.Models.RunnerModel();
            
            RunnerModels.Name = "";
            RunnerModels.SurName = "";
            RunnerModels.Email = "";
            RunnerModels.Club = "";
            RunnerModels.DNI = "";
            RunnerModels.GenderAvailables = _runnerManager.GetGenderDir().Select(x => new SelectListItem { Value = x.Key, Text = x.Value }).ToList();
            RunnerModels.DocumentTypeAvailables = _runnerManager.GetDocumentTypeDir().Select(x => new SelectListItem { Value = x.Key, Text = x.Value }).ToList();
            //RunnerModels.CompRunner.CategoryId = 0;
            //RunnerModels.CompRunner.CompetitionId = MvcApplication.GlobalCompetitionId;
            return PartialView(RunnerModels);
        }


        public ActionResult VerificaInscripcion()
        {
            var RunnerModels = new San_Silvestre.Models.RunnerModel();
            RunnerModels.DocumentTypeAvailables = _runnerManager.GetDocumentTypeDir().Select(x => new SelectListItem { Value = x.Key, Text = x.Value }).ToList();

            return PartialView(RunnerModels);
        }

        [HttpPost]
        public ActionResult VerificaRunner(string pDNI)
        {
            try
            {

                if (pDNI != null)
                {
                    var vrunner = _runnerManager.GetRunner(pDNI);
                    if (vrunner != null)
                    {

                        var runner = new Runner
                        {
                            Id = vrunner.Id,
                            Name = vrunner.Name,
                            SurName = vrunner.SurName,
                            DocumentTypeId = vrunner.DocumentTypeId,
                            YearBirthday = vrunner.YearBirthday,
                            DNI = vrunner.DNI,
                            Email = vrunner.Email,
                            Telephone = vrunner.Telephone,
                            PostalCode = vrunner.PostalCode,
                            GenderId = vrunner.GenderId,
                            IsLocalRunner = vrunner.IsLocalRunner,
                            Club = vrunner.Club,
                        };

                        return Json(new GenericOutput { Status = true, Message = "Inscrito", Data = runner }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new GenericOutput { Status = false, Message = "No existe nadie inscrito con ese DNI/NIE" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else {
                    return Json(new GenericOutput { Status = false, Message = "Inserte un DNI/NIE" }, JsonRequestBehavior.AllowGet);
                    }
            }
            catch (Exception exception)
            {
                //Logger.Error(exception);
                while (exception.InnerException != null) exception = exception.InnerException;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return Json(exception.Message, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult SaveRunner(RunnerModel runnerModel)
        {
            try
            {
                var runner = new Runner
                {
                    Id = runnerModel.Id,
                    Name = runnerModel.Name,
                    SurName = runnerModel.SurName,
                    DocumentTypeId = runnerModel.DocumentTypeId,
                    YearBirthday = runnerModel.YearBirthday,
                    DNI = runnerModel.DNI,
                    Email = runnerModel.Email,
                    Telephone = runnerModel.Telephone,
                    PostalCode = runnerModel.PostalCode,
                    GenderId = runnerModel.GenderId,
                    IsLocalRunner = runnerModel.IsLocalRunner,
                    Club = runnerModel.Club,
                    Dorsal = runnerModel.Dorsal
                };

                if (runnerModel.DNI != "")
                {
                    var vrunner = _runnerManager.GetRunner(runnerModel.DNI.ToUpper());
                    if (vrunner != null)
                    {
                        return Json(new GenericOutput { Status = false, Message = "El NIF/NIE número : " + runnerModel.DNI.ToUpper() + " ya se ha inscrito con anterioridad. Por favor compruebelo." }, JsonRequestBehavior.AllowGet);
                    }

                }

                var id = _runnerManager.SaveRunner(runner);

                //TODO: return the user object
                //Logger.Info(string.Format("User '{0}' {1}", id, userModel.UserId != 0 ? "edited" : "created"));
                //return Json(runnerModel, JsonRequestBehavior.AllowGet);
                return Json(new GenericOutput { Status = true, Message = "El corredor se ha inscrito correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                //Logger.Error(exception);
                while (exception.InnerException != null) exception = exception.InnerException;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return Json(exception.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}