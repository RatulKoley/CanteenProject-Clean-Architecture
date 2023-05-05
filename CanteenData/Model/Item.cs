using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.Model
{
	public class Item
	{
		public Item()
		{
			Purchase = new HashSet<Purchase>();
			FoodMapping = new HashSet<FoodMapping>();
		}
		[Key]
		public int ItemCode { get; set; }
		[StringLength(300, MinimumLength = 3)]
		public string ItemName { get; set; } = null!;
		[StringLength(int.MaxValue)]
		public string? Image { get; set; }
		public double ReorderLevel { get; set; }
		public bool IsActive { get; set; }
		[JsonIgnore]
		public virtual Unit? Unit { get; set; }
		public int? UnitId { get; set; }

		public virtual Stock? Stock { get; set; }
		public virtual ICollection<Purchase>? Purchase { get; set; }
		public virtual ICollection<FoodMapping>? FoodMapping { get; set; }
	}
}
