using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.Model
{
	public class Purchase
	{
		[Key]
		public int PurchaseNo { get; set; }
		public DateTime PurchasedDate { get; set; }
		[JsonIgnore]
		public virtual Item? Item { get; set; }
		public int? ItemId { get; set; }
		public double? Price { get; set; }
		public double? Quantity { get; set; }
		[JsonIgnore]
		public virtual Supply? Supply { get; set; }
		public int? SupplyId { get; set; }
		public double? PurchasedValue { get; set; }

	}
}
