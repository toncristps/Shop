using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "el campo Usuario es requerio")]
        [EmailAddress(ErrorMessage = "ingrese email valido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "el campo Contraseña es requerio")]
        [MinLength(6, ErrorMessage = "El campo Contraseña debe tener como minimo '6' caracteres.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
