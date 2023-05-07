using CanteenData.Model;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Context.ModelBuilderClass
{
	public static class CRMContextSales
	{
		public static ModelBuilder AddSalesModel(ModelBuilder modelBuilder)
		{
			return modelBuilder.Entity<Sales>(entity =>
			{
				entity.HasOne(_ => _.KitchenFood)
				   .WithMany(_ => _.Sales)
				   .HasForeignKey(_ => _.KitchenFoodID);
			});

		}
	}
}
