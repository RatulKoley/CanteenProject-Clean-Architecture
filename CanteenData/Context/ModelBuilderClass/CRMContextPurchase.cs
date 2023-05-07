using CanteenData.Model;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Context.ModelBuilderClass
{
	public static class CRMContextPurchase
	{
		public static ModelBuilder AddPurchaseModel(ModelBuilder modelBuilder)
		{
			return modelBuilder.Entity<Purchase>(ent =>
			{
				ent.HasOne(_ => _.Item)
				.WithMany(_ => _.Purchase)
				.HasForeignKey(_ => _.ItemId);

				ent.HasOne(_ => _.Supply)
				.WithMany(_ => _.Purchase)
				.HasForeignKey(_ => _.SupplyId);
			});
		}
	}
}
