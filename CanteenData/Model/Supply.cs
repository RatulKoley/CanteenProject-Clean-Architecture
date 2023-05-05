using System.ComponentModel.DataAnnotations;

namespace CanteenData.Model
{
	public class Supply
	{
		public Supply()
		{
			Purchase = new HashSet<Purchase>();
		}
		public int SupplyID { get; set; }
		[StringLength(300, MinimumLength = 3)]
		public string SupplierName { get; set; } = null!;
		public bool IsActive { get; set; }
		public virtual ICollection<Purchase>? Purchase { get; set; }
	}
}
