using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;

namespace CanteenData.Interface
{
	public interface ISupplyRepository
	{
		public SupplyListViewModel SupplyList();
		public SupplyViewModel GetSupply(int id);
		public SupplyViewModel AddSupply(SupplyViewModel newsupply);
		public SupplyViewModel UpdateSupply(SupplyViewModel updatesupply, int id);
		public SupplyViewModel DeleteSupply(int id);
	}
}
