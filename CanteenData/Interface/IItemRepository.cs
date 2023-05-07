using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;

namespace CanteenData.Interface
{
	public interface IItemRepository
	{
		public ItemListViewModel GetAllItem();
		public ItemViewModel GetItemByID(int id);
		public ItemViewModel AddItem(ItemViewModel newitem);
		public ItemViewModel EditItem(ItemViewModel edititem, int id);
		public ItemViewModel DeleteItem(int id);
	}
}
