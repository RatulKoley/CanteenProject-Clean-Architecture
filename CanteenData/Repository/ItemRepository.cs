using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Model;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Repository
{
	public class ItemRepository : IItemRepository
	{
		private readonly DataContext _con;
		public ItemRepository(DataContext con)
		{
			_con = con;
		}
		public ItemListViewModel GetAllItem(ItemListViewModel objModel)
		{
			var ItemData = _con.Item.Include(test => test.Stock).Include(test => test.Purchase)
			.Include(test => test.FoodMapping).ToList();
			ItemListViewModel newitem = new ItemListViewModel();
			newitem.itemlist = ItemData;
			return newitem;
		}
		public ItemViewModel GetItemByID(int id)
		{
			var result = _con.Item.Include(test => test.Stock).Include(test => test.Purchase).Include(test => test.FoodMapping)
			.Where(test => test.ItemCode == id).FirstOrDefault();
			ItemViewModel newitem = new ItemViewModel();
			if (result != null)
			{
				newitem.itemmodel = result;
			}
			return newitem;
		}
		public ItemViewModel AddItem(ItemViewModel newitem)
		{
			ItemViewModel justitem = new ItemViewModel();
			var result = _con.Unit.Where(test => test.ID == newitem.itemmodel.UnitId).FirstOrDefault();
			if (result == null)
			{
				return justitem;
			}
			Item i1 = new Item();
			i1.ItemName = newitem.itemmodel.ItemName;
			i1.Image = newitem.itemmodel.Image;
			i1.ReorderLevel = newitem.itemmodel.ReorderLevel;
			i1.IsActive = true;
			i1.UnitId = newitem.itemmodel.UnitId;
			_con.Item.Add(i1);
			_con.SaveChanges();
			justitem.itemmodel = i1;
			return justitem;
		}
		public ItemViewModel EditItem(ItemViewModel edititem)
		{
			ItemViewModel justitem = new ItemViewModel();
			var result = _con.Unit.Where(test => test.ID == edititem.itemmodel.UnitId).FirstOrDefault();
			if (result == null)
			{
				return justitem;
			}
			Item i1 = new Item();
			i1.ItemCode = edititem.itemmodel.ItemCode;
			i1.ItemName = edititem.itemmodel.ItemName;
			i1.Image = edititem.itemmodel.Image;
			i1.ReorderLevel = edititem.itemmodel.ReorderLevel;
			i1.IsActive = edititem.itemmodel.IsActive;
			i1.UnitId = edititem.itemmodel.UnitId;
			_con.Item.Update(i1);
			_con.SaveChanges();
			return edititem;
		}
		public ItemViewModel DeleteItem(int id)
		{
			ItemViewModel justitem = new ItemViewModel();
			var result = _con.Item.Where(test => test.ItemCode == id).FirstOrDefault();
			if (result == null)
			{
				return justitem;
			}
			result.IsActive = false;
			_con.Item.Update(result);
			_con.SaveChanges();
			justitem.itemmodel = result;
			return justitem;
		}
	}
}
