using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.DTO
{
	public class ItemDTO
	{
		public int ItemCode { get; set; }
		[StringLength(300, MinimumLength = 3)]
		public string ItemName { get; set; } = null!;
		[StringLength(int.MaxValue)]
		public string? Image { get; set; }
		public double ReorderLevel { get; set; }
		public string? UnitName { get; set; }
		[JsonIgnore]
		public int? UnitId { get; set; }
		public bool IsActive { get; set; } = true;
	}
}
