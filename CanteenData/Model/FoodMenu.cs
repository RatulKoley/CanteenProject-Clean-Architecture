using System.ComponentModel.DataAnnotations;

namespace CanteenData.Model
{
	public class FoodMenu
	{
		public FoodMenu()
		{
			FoodMapping = new HashSet<FoodMapping>();
		}
		[Key]
		public int FoodID { get; set; }
		[StringLength(200, MinimumLength = 3)]
		public string FoodName { get; set; } = null!;
		public double? Price { get; set; }
		public bool IsActive { get; set; }
		public virtual ICollection<FoodMapping>? FoodMapping { get; set; }
		public virtual KitchenFood? KitchenFood { get; set; }
	}
}
