using CanteenData.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.DTO
{
	public class UnitDTO
	{
		public int ID { get; set; }
		[StringLength(50, MinimumLength = 3)]
		public string UnitName { get; set; } = null!;
		public bool IsActive { get; set; } = true;
		[JsonIgnore]
		public virtual ICollection<Item>? Item { get; set; }
	}
}
