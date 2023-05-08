using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class KitchenFood
    {
        public KitchenFood()
        {
            Sales = new HashSet<Sale>();
        }

        public int KitchenFoodId { get; set; }
        public int? FoodId { get; set; }
        public double? QuantityPrepared { get; set; }
        public DateTime PreparedDate { get; set; }

        public virtual FoodMenu? Food { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
