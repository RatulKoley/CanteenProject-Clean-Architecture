using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.Model
{
	public class FoodMapping
	{
		[Key]
		public int MappingID { get; set; }
		[JsonIgnore]
		public virtual FoodMenu? FoodMenu { get; set; }
		public int? FoodID { get; set; }
		public double? FoodQuantity { get; set; }
		[JsonIgnore]
		public virtual Item? Item { get; set; }
		public int? ItemId { get; set; }
		public double? ItemQuantity { get; set; }
		public bool Active { get; set; }

	}
}
