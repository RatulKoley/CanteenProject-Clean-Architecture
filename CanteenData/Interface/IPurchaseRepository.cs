using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;

namespace CanteenData.Interface
{
	public interface IPurchaseRepository
	{
		public PurchaseListViewModel PurchaseList();
		public PurchaseViewModel GetPurchase(int id);
		public PurchaseViewModel AddPurchase(PurchaseViewModel newpurchase);
		public PurchaseViewModel UpdatePurchase(PurchaseViewModel updatepurchase, int id);
		public PurchaseViewModel DeletePurchase(int id);
	}
}
