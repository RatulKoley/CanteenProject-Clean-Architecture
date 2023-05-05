using CanteenData.Model;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> opt) : base(opt)
		{

		}
		public virtual DbSet<Item> Item { get; set; }
		public virtual DbSet<Supply> Supply { get; set; }
		public virtual DbSet<Stock> Stock { get; set; }
		public virtual DbSet<Unit> Unit { get; set; }
		public virtual DbSet<Purchase> Purchase { get; set; }
		public virtual DbSet<FoodMenu> FoodMenu { get; set; }
		public virtual DbSet<FoodMapping> FoodMapping { get; set; }
		public virtual DbSet<KitchenFood> KitchenFood { get; set; }
		public virtual DbSet<Sales> Sales { get; set; }
	}
}
