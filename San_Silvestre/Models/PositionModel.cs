using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace San_Silvestre.Models
{
    public class PositionModel
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public Nullable<int> PositionId { get; set; }
        public Nullable<int> GeneralPosition { get; set; }
        public Nullable<int> Dorsal { get; set; }
        public int RunnerId { get; set; }
        public string RunnerName { get; set; }
        public string Club { get; set; }
        public string Elapsed_Time { get; set; }
        public int CategoryId { get; set; }
        public int UniqueCategoryCompId { get; set; }

        [Display(Name = "Sexo")]
        public string GenderId { get; set; }
        public List<System.Web.Mvc.SelectListItem> GenderAvailables { get; set; }

        public List<System.Web.Mvc.SelectListItem> CategoryAvailables { get; set; }
    }

    public class MyCategoriesDescriptions
    {
        public int MyCategoryId { get; set; }
        public string MyCategoryDescription { get; set; }
    }
}