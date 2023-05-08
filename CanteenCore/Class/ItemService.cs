using CanteenCore.Interface;
using CanteenData.Interface;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Class
{
	public class ItemService : IItemService
	{
		private readonly IItemRepository _iitemrepo;
		public ItemService(IItemRepository iitemrepo)
		{
			_iitemrepo = iitemrepo;
		}
		public ItemListViewModel GetAllItem()
		{
			return _iitemrepo.GetAllItem();
		}
		public ItemViewModel GetItemByID(int id)
		{
			return _iitemrepo.GetItemByID(id);
		}
		public ItemViewModel AddItem(ItemViewModel newitem)
		{
			return _iitemrepo.AddItem(newitem);
		}
		public ItemViewModel EditItem(ItemViewModel edititem, int id)
		{
			return _iitemrepo.EditItem(edititem, id);
		}
		public ItemViewModel DeleteItem(int id)
		{
			return _iitemrepo.DeleteItem(id);
		}

	}
}
