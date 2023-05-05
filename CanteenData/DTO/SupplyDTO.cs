using System.ComponentModel.DataAnnotations;

namespace CanteenData.DTO
{
	public class SupplyDTO
	{
		public int SupplyID { get; set; }
		[StringLength(300, MinimumLength = 3)]
		public string SupplierName { get; set; } = null!;
		public bool IsActive { get; set; } = true;
	}
}
