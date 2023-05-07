using CanteenData.Model;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Context.ModelBuilderClass
{
	public static class CRMContextKitchenFood
	{
		public static ModelBuilder AddKitchenFoodModel(ModelBuilder modelBuilder)
		{
			return modelBuilder.Entity<KitchenFood>(ent =>
			{
				ent.HasOne(_ => _.FoodMenu)
				.WithOne(_ => _.KitchenFood)
				.HasForeignKey<KitchenFood>(_ => _.FoodID);
			});
		}
	}
}
