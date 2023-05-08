using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class Supply
    {
        public Supply()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int SupplyId { get; set; }
        public string SupplierName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
