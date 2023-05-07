using CanteenCore.Interface;
using CanteenData.Interface;
using CanteenData.ViewModel.ViewModelList;
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
		public ItemListViewModel GetAllItem(ItemListViewModel objModel)
		{
			return _iitemrepo.GetAllItem(objModel);
		}
		public ItemViewModel GetItemByID(int id)
		{
			return _iitemrepo.GetItemByID(id);
		}
		public ItemViewModel AddItem(ItemViewModel newitem)
		{
			return _iitemrepo.AddItem(newitem);
		}
		public ItemViewModel EditItem(ItemViewModel edititem)
		{
			return _iitemrepo.EditItem(edititem);
		}
		public ItemViewModel DeleteItem(int id)
		{
			return _iitemrepo.DeleteItem(id);
		}

	}
}
