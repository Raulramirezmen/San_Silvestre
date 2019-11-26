using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace San_Silvestre.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduce una Categoria", AllowEmptyStrings = false)]
        [Display(Name = "Categoria")]
        public string Name { get; set; }
    }
}