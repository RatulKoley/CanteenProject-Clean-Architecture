using CanteenCore.Interface;
using CanteenData.Interface;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Class
{
	public class PurchaseService : IPurchaseService

	{
		private readonly IPurchaseRepository _purchaserepo;
		public PurchaseService(IPurchaseRepository purchaserepo)
		{
			_purchaserepo = purchaserepo;
		}
		public PurchaseListViewModel PurchaseList()
		{
			return _purchaserepo.PurchaseList();
		}
		public PurchaseViewModel GetPurchase(int id)
		{
			return _purchaserepo.GetPurchase(id);
		}
		 public PurchaseViewModel AddPurchase(PurchaseViewModel newpurchase)
		{
			return _purchaserepo.AddPurchase(newpurchase);
		}
		public PurchaseViewModel UpdatePurchase(PurchaseViewModel updatepurchase, int id)
		{
			return _purchaserepo.UpdatePurchase(updatepurchase,id);
		}
		 public PurchaseViewModel DeletePurchase(int id)
		{
			return _purchaserepo.DeletePurchase(id);
		}

	}
}
