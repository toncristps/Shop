namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RecoverPasswordViewModel
    {
        [Required(ErrorMessage = "el campo email es requerido")]
        [EmailAddress(ErrorMessage = "ingrese email valido")]
        public string Email { get; set; }
    }

}
