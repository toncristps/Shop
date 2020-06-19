namespace Shop.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ChangeUserViewModel
    {
        [Required(ErrorMessage = "el campo Nombre es requerido")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "el campo Apellido es requerido")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "el campo Dirección es requerido")]
        [MaxLength(100, ErrorMessage = "El campo Dirección solo puede contener como maximo {1} caracteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "el campo Celular es requerido")]
        [MinLength(9, ErrorMessage = "el campo Celular debe contener como minimo {1} caracters.")]
        [MaxLength(20, ErrorMessage = "el campo Celular solo puede contener como maximo {1} caracters.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "el campo Ciudad es requerido")]
        [Display(Name = "Ciudad")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione su Ciudad.")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        [Required(ErrorMessage = "el campo País es requerido")]
        [Display(Name = "País")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione su País.")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

    }

}
