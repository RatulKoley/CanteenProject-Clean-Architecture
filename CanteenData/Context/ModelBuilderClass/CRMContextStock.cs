using CanteenData.Model;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Context.ModelBuilderClass
{
	public static class CRMContextStock
	{
		public static ModelBuilder AddStockModel(ModelBuilder modelBuilder)
		{
			return modelBuilder.Entity<Stock>(ent =>
			{
				ent.HasOne(_ => _.Item)
				.WithOne(_ => _.Stock)
				.HasForeignKey<Stock>(_ => _.ItemId);
			});
		}
	}
}
