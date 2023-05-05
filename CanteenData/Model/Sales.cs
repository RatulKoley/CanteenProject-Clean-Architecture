using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.Model
{
	public class Sales
	{
		[Key]
		public int SalesID { get; set; }
		[StringLength(200, MinimumLength = 3)]
		public string CustomerName { get; set; } = null!;
		public string? CustomerType { get; set; }
		[JsonIgnore]
		public virtual KitchenFood? KitchenFood { get; set; }
		public int? KitchenFoodID { get; set; }
		public double? Quantity { get; set; }
		public double? Price { get; set; }
		public double? Cash { get; set; } = 0;
		[StringLength(maximumLength: 4, MinimumLength = 4)]
		[RegularExpression("^[0 - 9]{4} $")]
		public int? CreditCardNo { get; set; } = 0000;
		public double? Credit { get; set; } = 0;
		public double? UPI { get; set; } = 0;


	}
}
