using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Interface
{
	public interface IPurchaseService
	{
		public PurchaseListViewModel PurchaseList();
		public PurchaseViewModel GetPurchase(int id);
		public PurchaseViewModel AddPurchase(PurchaseViewModel newpurchase);
		public PurchaseViewModel UpdatePurchase(PurchaseViewModel updatepurchase, int id);
		public PurchaseViewModel DeletePurchase(int id);
	}
}
