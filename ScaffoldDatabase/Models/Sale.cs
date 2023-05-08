using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class Sale
    {
        public int SalesId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? CustomerType { get; set; }
        public int? KitchenFoodId { get; set; }
        public double? Quantity { get; set; }
        public double? Price { get; set; }
        public double? Cash { get; set; }
        public int? CreditCardNo { get; set; }
        public double? Credit { get; set; }
        public double? Upi { get; set; }

        public virtual KitchenFood? KitchenFood { get; set; }
    }
}
