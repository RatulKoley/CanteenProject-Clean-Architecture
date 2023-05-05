using System.Text.Json.Serialization;

namespace CanteenData.DTO
{
	public class FoodMapppingDTO
	{
		public int MappingID { get; set; }
		public string? FoodName { get; set; }
		[JsonIgnore]
		public int? FoodID { get; set; }
		public double? FoodQuantity { get; set; }
		public string? ItemName { get; set; }
		[JsonIgnore]
		public int? ItemId { get; set; }
		public double? ItemQuantity { get; set; }
		public bool Active { get; set; }
	}
}
