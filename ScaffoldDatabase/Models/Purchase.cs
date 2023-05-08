using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class Purchase
    {
        public int PurchaseNo { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int? ItemId { get; set; }
        public double? Price { get; set; }
        public double? Quantity { get; set; }
        public int? SupplyId { get; set; }
        public double? PurchasedValue { get; set; }

        public virtual Item? Item { get; set; }
        public virtual Supply? Supply { get; set; }
    }
}
