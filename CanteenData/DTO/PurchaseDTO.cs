using System.Text.Json.Serialization;

namespace CanteenData.DTO
{
	public class PurchaseDTO
	{
		public int PurchaseNo { get; set; }
		public DateTime PurchasedDate { get; set; }
		public string? ItemName { get; set; }
		[JsonIgnore]
		public int? ItemId { get; set; }
		public double? Price { get; set; }
		public double? Quantity { get; set; }
		public string? Suppliermame { get; set; }
		[JsonIgnore]
		public int? SupplyId { get; set; }
		[JsonIgnore]
		public double? PurchasedValue { get; set; }
	}
}
