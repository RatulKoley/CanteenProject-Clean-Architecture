using System.ComponentModel.DataAnnotations;

namespace CanteenData.Model
{
	public class Unit
	{
		public Unit()
		{
			Item = new HashSet<Item>();
		}
		[Key]
		public int ID { get; set; }
		[StringLength(50, MinimumLength = 3)]
		public string UnitName { get; set; } = null!;
		public bool IsActive { get; set; }
		public virtual ICollection<Item>? Item { get; set; }

	}
}
