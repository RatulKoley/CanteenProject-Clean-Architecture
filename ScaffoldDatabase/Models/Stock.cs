using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public int? ItemId { get; set; }
        public double? Qunatity { get; set; }

        public virtual Item? Item { get; set; }
    }
}
