using CanteenData.Model;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Context.ModelBuilderClass
{
	public static class CRMContextFoodMapping
	{
		public static ModelBuilder AddFoodMappingModel(ModelBuilder modelBuilder)
		{
			return modelBuilder.Entity<FoodMapping>(ent =>
			{
				ent.HasOne(_ => _.FoodMenu)
				.WithMany(_ => _.FoodMapping)
				.HasForeignKey(_ => _.FoodID);

				ent.HasOne(_ => _.Item)
				.WithMany(_ => _.FoodMapping)
				.HasForeignKey(_ => _.ItemId);
			});
		}
	}
}
