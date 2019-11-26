using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanSil.BLL.Position.Interface;
using SanSil.BLL.Position.Models;
using San_Silvestre.Models;

namespace San_Silvestre.Controllers
{
    public class PositionController : Controller
    {

        public readonly IPositionManager _positionManager;

        public PositionController(IPositionManager positionManager) : base()
        {
             _positionManager = positionManager;
        }


        // GET: Position
        public ActionResult Index()
        {

            int vCategory = 15;

            var BLLpositionModels = _positionManager.GetAllRunners(vCategory);

            var positionModels = BLLpositionModels.Select(x => new PositionModel
            {
                Id = x.Id,
                CompetitionId = x.CompetitionId,
                PositionId = x.PositionId,
                GeneralPosition = x.GeneralPosition,
                Dorsal = x.Dorsal,
                RunnerId = x.RunnerId,
                RunnerName = x.RunnerName + ' ' + x.RunnerSurName,
                Club = x.Club,
                Elapsed_Time = x.Elapsed_Time,
                CategoryId = x.CategoryId,
                GenderId = x.GenderId,
            }).ToList();

            SelectList selectList = new SelectList(_positionManager.GetCategoryDescriptions(), "Key", "Value", vCategory);
            ViewData["CategoriesAvailable"] = selectList;

            return View(positionModels);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult RefreshRunnerPosition(int pCategory)
        {
  
            var BLLpositionModels = _positionManager.GetAllRunners(pCategory);

            var positionModels = BLLpositionModels.Select(x => new PositionModel
            {
                Id = x.Id,
                CompetitionId = x.CompetitionId,
                PositionId = x.PositionId,
                GeneralPosition = x.GeneralPosition,
                Dorsal = x.Dorsal,
                RunnerId = x.RunnerId,
                RunnerName = x.RunnerName + ' ' + x.RunnerSurName,
                Club = x.Club,
                Elapsed_Time = x.Elapsed_Time,
                CategoryId = x.CategoryId,
                GenderId = x.GenderId,
            }).ToList();

            //SelectList selectList = new SelectList(_positionManager.GetCategoryDescriptions(), "Key", "Value", "10");
            //ViewData["CategoriesAvailable"] = selectList;

            return PartialView("PositionView", positionModels);
        }

    }
}