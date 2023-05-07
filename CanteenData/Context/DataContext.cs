using CanteenData.Context.ModelBuilderClass;
using CanteenData.Model;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Context
{
	public class DataContext : DbContext
	{
		//private readonly DbContextOptions _context;
		public DataContext(DbContextOptions<DataContext> opt) : base(opt)
		{ }
		//public DataContext(DbContextOptions opt) : base(opt)
		//{
		//	_context = opt;
		//}
		public virtual DbSet<Item> Item { get; set; }
		public virtual DbSet<Supply> Supply { get; set; }
		public virtual DbSet<Stock> Stock { get; set; }
		public virtual DbSet<Unit> Unit { get; set; }
		public virtual DbSet<Purchase> Purchase { get; set; }
		public virtual DbSet<FoodMenu> FoodMenu { get; set; }
		public virtual DbSet<FoodMapping> FoodMapping { get; set; }
		public virtual DbSet<KitchenFood> KitchenFood { get; set; }
		public virtual DbSet<Sales> Sales { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			CRMContextItem.AddItemModel(modelBuilder);
			CRMContextStock.AddStockModel(modelBuilder);
			CRMContextPurchase.AddPurchaseModel(modelBuilder);
			CRMContextFoodMapping.AddFoodMappingModel(modelBuilder);
			CRMContextKitchenFood.AddKitchenFoodModel(modelBuilder);
			CRMContextSales.AddSalesModel(modelBuilder);



		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				string connectionString = "Server=DESKTOP-D20GNE0\\SQLEXPRESS;Database={tenant};Integrated Security=true;";
				optionsBuilder.UseSqlServer(connectionString.Replace("{tenant}", "CanteenDB"));
			}

		}


	}
}
