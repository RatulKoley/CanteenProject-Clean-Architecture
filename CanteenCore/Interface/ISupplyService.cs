using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Interface
{
	public interface ISupplyService
	{
		public SupplyListViewModel SupplyList();
		public SupplyViewModel GetSupply(int id);
		public SupplyViewModel AddSupply(SupplyViewModel newsupply);
		public SupplyViewModel UpdateSupply(SupplyViewModel updatesupply,int id);
		public SupplyViewModel DeleteSupply(int id);
	}
}
