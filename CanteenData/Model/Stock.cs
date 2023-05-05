using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CanteenData.Model
{
	public class Stock
	{
		[Key]
		public int StockID { get; set; }
		[JsonIgnore]
		public virtual Item? Item { get; set; }
		public int? ItemId { get; set; }
		public double? Qunatity { get; set; }

	}
}
