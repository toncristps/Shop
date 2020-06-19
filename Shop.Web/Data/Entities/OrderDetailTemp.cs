namespace Shop.Web.Data.Entities
{
	using System.ComponentModel.DataAnnotations;

	public class OrderDetailTemp : IEntity
	{
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		[Display(Name = "Producto")]
		[Required]
		public Product Product { get; set; }

		[Display(Name = "Precio")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal Price { get; set; }

		[Display(Name = "Cantidad")]
		[DisplayFormat(DataFormatString = "{0:N2}")]
		public double Quantity { get; set; }

		[Display(Name = "Valor")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal Value { get { return this.Price * (decimal)this.Quantity; } }
	}

}
