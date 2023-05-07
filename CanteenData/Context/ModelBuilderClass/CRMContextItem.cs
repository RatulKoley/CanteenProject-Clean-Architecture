using CanteenData.Model;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Context.ModelBuilderClass
{
	public static class CRMContextItem
	{
		public static ModelBuilder AddItemModel(ModelBuilder modelBuilder)
		{
			return modelBuilder.Entity<Item>(entity =>
			{
				entity.HasOne(_ => _.Unit)
				 .WithMany(_ => _.Item)
				 .HasForeignKey(_ => _.UnitId);
			});


		}
	}
}
