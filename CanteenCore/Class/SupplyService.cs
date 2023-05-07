using CanteenCore.Interface;
using CanteenData.Interface;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Class
{
	public class SupplyService : ISupplyService
	{
		private readonly ISupplyRepository _supplyrepo;
		public SupplyService(ISupplyRepository supplyrepo)
		{
			_supplyrepo = supplyrepo;
		}
		public SupplyListViewModel SupplyList()
		{
			return _supplyrepo.SupplyList();
		}
		public SupplyViewModel GetSupply(int id)
		{
			return _supplyrepo.GetSupply(id);
		}
		public SupplyViewModel AddSupply(SupplyViewModel newsupply)
		{
			return _supplyrepo.AddSupply(newsupply);
		}
		public SupplyViewModel UpdateSupply(SupplyViewModel updatesupply, int id)
		{
			return _supplyrepo.UpdateSupply(updatesupply, id);
		}
		public SupplyViewModel DeleteSupply(int id)
		{
			return _supplyrepo.DeleteSupply(id);
		}
	}
}
