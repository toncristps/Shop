namespace Shop.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddItemViewModel
    {
        [Display(Name = "Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un producto.")]
        public int ProductId { get; set; }

        [Display(Name = "Cantidad")]
        [Range(5.0000, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor igual a 5 kg.")]
        public double Quantity { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
    }

}
