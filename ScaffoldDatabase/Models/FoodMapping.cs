using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class FoodMapping
    {
        public int MappingId { get; set; }
        public int? FoodId { get; set; }
        public double? FoodQuantity { get; set; }
        public int? ItemId { get; set; }
        public double? ItemQuantity { get; set; }
        public bool Active { get; set; }

        public virtual FoodMenu? Food { get; set; }
        public virtual Item? Item { get; set; }
    }
}
