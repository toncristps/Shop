namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "el campo Usuario es requerido")]
        [EmailAddress(ErrorMessage = "ingrese email valido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "el campo Usuario es requerido")]
        [MinLength(6, ErrorMessage = "El campo Contraseña debe tener como minimo '6' caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "el campo Usuario es requerido")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "'Confirmar Contraseña' y 'Contraseña' no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }
    }

}
