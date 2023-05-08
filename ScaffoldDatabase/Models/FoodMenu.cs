using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class FoodMenu
    {
        public FoodMenu()
        {
            FoodMappings = new HashSet<FoodMapping>();
        }

        public int FoodId { get; set; }
        public string FoodName { get; set; } = null!;
        public double? Price { get; set; }
        public bool IsActive { get; set; }

        public virtual KitchenFood? KitchenFood { get; set; }
        public virtual ICollection<FoodMapping> FoodMappings { get; set; }
    }
}
