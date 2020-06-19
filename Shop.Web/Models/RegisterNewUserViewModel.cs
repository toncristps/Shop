namespace Shop.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class RegisterNewUserViewModel
    {
        [Required(ErrorMessage ="el campo Nombre es requerido")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="el campo Apellido es requerio")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "el campo Usuario es requerio")]
        [EmailAddress(ErrorMessage =  "ingrese email valido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "el campo Direccíon es requerio")]
        [MaxLength(100, ErrorMessage = "el Campo Direccíon solo puede contener {1} caracteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "el campo Celular es requerio")]
        [MinLength(9, ErrorMessage = "el campo Celular debe contener como minimo {1} caracters.")]
        [MaxLength(20, ErrorMessage = "el campo Celular debe contener como maximo {1} caracters.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ciudad")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione su Ciudad.")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        [Display(Name = "País")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione su País.")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }


        [Required(ErrorMessage = "el campo Contraseña es requerio")]
        [MinLength(6, ErrorMessage = "El campo Contraseña debe tener como minimo '6' caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "el campo Confirmar Contraseña es requerio")]
        [Compare("Password", ErrorMessage = "'Confirmar Contraseña' y 'Contraseña' no coinciden.")]
        public string Confirm { get; set; }
    }

}
