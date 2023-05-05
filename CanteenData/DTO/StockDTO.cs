using System.Text.Json.Serialization;

namespace CanteenData.DTO
{
	public class StockDTO
	{
		public int StockID { get; set; }
		public string? ItemName { get; set; }
		[JsonIgnore]
		public int? ItemId { get; set; }
		public double? Qunatity { get; set; }
	}
}
