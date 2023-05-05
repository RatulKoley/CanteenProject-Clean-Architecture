using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.Model
{
	public class KitchenFood
	{
		public KitchenFood()
		{
			Sales = new HashSet<Sales>();
		}
		[Key]
		public int KitchenFoodID { get; set; }
		[JsonIgnore]
		public virtual FoodMenu? FoodMenu { get; set; }
		public int? FoodID { get; set; }
		public double? QuantityPrepared { get; set; }
		public DateTime PreparedDate { get; set; }
		public virtual ICollection<Sales>? Sales { get; set; }
	}
}
