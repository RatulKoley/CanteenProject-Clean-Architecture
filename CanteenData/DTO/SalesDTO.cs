using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.DTO
{
	public class SalesDTO
	{
		public int SalesID { get; set; }
		[StringLength(200, MinimumLength = 3)]
		public string CustomerName { get; set; } = null!;
		public string? CustomerType { get; set; }
		public string? KitchenFoodName { get; set; }
		[JsonIgnore]
		public int? KitchenFoodID { get; set; }
		public double? Quantity { get; set; }
		[JsonIgnore]
		public double? Price { get; set; } = 0;
		public double? Cash { get; set; } = 0;
		// [StringLength(4)]
		[StringLength(maximumLength: 4, MinimumLength = 4)]
		[RegularExpression("^[0-9]+$")]
		public int? CreditCardNo { get; set; } = 1234;
		public double? Credit { get; set; } = 0;
		public double? UPI { get; set; } = 0;
	}
}
