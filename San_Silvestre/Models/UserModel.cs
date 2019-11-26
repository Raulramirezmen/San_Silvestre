using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace San_Silvestre.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Introduce un Nombre de Usuario", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "{0} debe ser al menos de {2} caracteres.", MinimumLength = 8)]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Introduce una Contraseña", AllowEmptyStrings = false)]
        [StringLength(30, ErrorMessage = "{0} debe ser al menos de {2} caracteres.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma contraseña")]
        [Compare("Password", ErrorMessage = "Contraseña y su confirmacion no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Introduce Nombre y Apellidos", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "{0} debe ser al menos de {2} caracteres.", MinimumLength = 8)]
        [Display(Name = "Nombre")]
        public string FullName { get; set; }

        [Display(Name = "Selecciona un Role")]
        public RoleModel Role { get; set; }

        [RegularExpression(@"([0-9a-zA-Z]+[\+\-_\.])*[0-9a-zA-Z]+@([0-9a-zA-Z]+[.])+[a-zA-Z]{2,3}", ErrorMessage = "Introuduce un email valido")]
        [Display(Name = "E-mail")]
        public string EmailID { get; set; }
        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Rol es requerido")]
        public int RoleId { get; set; }
        [Display(Name = "Rol")]
        public List<System.Web.Mvc.SelectListItem> Roles { get; set; }

        [Range(-1, 0, ErrorMessage = "Usuario ya existe.")]
        public int ExistingId { get; set; }
    }

    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}