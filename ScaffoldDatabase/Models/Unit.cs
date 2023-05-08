using System;
using System.Collections.Generic;

namespace ScaffoldDatabase.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string UnitName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
