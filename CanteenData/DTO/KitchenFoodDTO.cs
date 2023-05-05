using CanteenData.Model;
using System.Text.Json.Serialization;

namespace CanteenData.DTO
{
	public class KitchenFoodDTO
	{
		public int KitchenFoodID { get; set; }
		public string? FoodName { get; set; }
		[JsonIgnore]
		public int? FoodID { get; set; }
		public double? QuantityPrepared { get; set; }
		public DateTime PreparedDate { get; set; }
		[JsonIgnore]
		public virtual ICollection<Sales>? Sales { get; set; }
	}
}
