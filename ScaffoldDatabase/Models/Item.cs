using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class Item
    {
        public Item()
        {
            FoodMappings = new HashSet<FoodMapping>();
            Purchases = new HashSet<Purchase>();
        }

        public int ItemCode { get; set; }
        public string ItemName { get; set; } = null!;
        public string? Image { get; set; }
        public double ReorderLevel { get; set; }
        public bool IsActive { get; set; }
        public int? UnitId { get; set; }

        public virtual Unit? Unit { get; set; }
        public virtual Stock? Stock { get; set; }
        public virtual ICollection<FoodMapping> FoodMappings { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
