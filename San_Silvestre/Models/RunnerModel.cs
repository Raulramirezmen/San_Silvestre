using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace San_Silvestre.Models
{
    public class RunnerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduce un Nombre", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "{0} debe estar comprendido entre {2} y {1} caractéres.", MinimumLength = 2)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Introduce Apellidos", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "{0} debe estar comprendido entre {2} y {1} caractéres.", MinimumLength = 8)]
        [Display(Name = "Apellidos")]
        public string SurName { get; set; }

        [RegularExpression(@"([0-9a-zA-Z]+[\+\-_\.])*[0-9a-zA-Z]+@([0-9a-zA-Z]+[.])+[a-zA-Z]{2,3}", ErrorMessage = "Introduce un email valido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [RegularExpression(@"([0-9a-zA-Z]+[\+\-_\.])*[0-9a-zA-Z]+@([0-9a-zA-Z]+[.])+[a-zA-Z]{2,3}", ErrorMessage = "Introduce un email valido")]
        [Display(Name = "Repite Email")]
        [Compare("Email", ErrorMessage = "Email y su confirmacion no coinciden.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Pertenece Club")]
        public string Club { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Solo números")]
        [Range(1900, 2015, ErrorMessage = "Año Nacimiento entre 1900 y 2015")]
        [Required(ErrorMessage = "Año de nacimiento es un dato requerido", AllowEmptyStrings = false)]
        [Display(Name = "Año Nacimiento")]
        public int YearBirthday { get; set; }

        [Required(ErrorMessage = "Sexo es requerido", AllowEmptyStrings = false)]
        [Display(Name = "Sexo")]
        public string GenderId { get; set; }

        [RegularExpression("[0-9]*", ErrorMessage = "Introduce un Código Postal valido")]
        //[DataType(DataType.PostalCode)]
        [Display(Name = "Cod. Postal")]
        public int? PostalCode { get; set; }

        [Display(Name = "Telefono")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sin espacios y solo números")]
        public int? Telephone { get; set; }

        //[RegularExpression("^(([A-Z]\\d{8})|(\\d{8}[A-Z]))$", ErrorMessage = "DNI incorrecto")]
        //[Display(Name = "Ingrese su DNI")]
        //public string DNI { get; set; }

        public int DocumentTypeId { get; set; }
        [Display(Name = "DNI,NIE")]
        public string DNI { get; set; }

        [Display(Name = "Corredor Local?")]
        public bool IsLocalRunner { get; set; }

        public List<System.Web.Mvc.SelectListItem> GenderAvailables { get; set; }
        [Display(Name = "DNI,NIE")]
        public List<System.Web.Mvc.SelectListItem> DocumentTypeAvailables { get; set; }

        [Display(Name = "Dorsal")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Solo números")]
        public int? Dorsal { get; set; }

        [Display(Name = "Categoria")]
        public string Categoria { get; set; }


        //public CompetitionRunnerModel CompRunner { get; set; }

    }
    //public class CompetitionRunnerModel
    //{
    //    public int RunnerId { get; set; }
    //    public int CompetitionId { get; set; }
    //    public int CategoryId { get; set; }
    //    public int Dorsal { get; set; }
    //    public int Position { get; set; }
    //    public int GeneralPosition { get; set; }
    //    public DateTime ElapsedTime { get; set; }
    //}
}