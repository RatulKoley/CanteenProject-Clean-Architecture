using CanteenData.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.DTO
{
	public class FoodMenuDTO
	{
		public int FoodID { get; set; }
		[StringLength(200, MinimumLength = 3)]
		public string FoodName { get; set; } = null!;
		public double? Price { get; set; }
		public bool IsActive { get; set; } = true;
		[JsonIgnore]
		public virtual ICollection<FoodMapping>? FoodMapping { get; set; }
	}
}
