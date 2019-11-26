using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace San_Silvestre.Models
{
    public class GenderModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Introduce un Genero", AllowEmptyStrings = false)]
        [Display(Name = "Genero")]
        public string Name { get; set; }
    }
}