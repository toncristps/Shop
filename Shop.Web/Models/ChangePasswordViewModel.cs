namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "el campo Contraseña Actual es requerido")]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "el campo Nueva Contraseña es requerido")]
        [MinLength(6, ErrorMessage = "El campo Contraseña debe tener como minimo '6' caracteres.")]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "el campo Confirmar Nueva Contraseña es requerido")]
        [Compare("NewPassword", ErrorMessage = "'Confirmar Nueva Contraseña' y 'Nueva contraseña' no coinciden.")]
        public string Confirm { get; set; }
    }

}
