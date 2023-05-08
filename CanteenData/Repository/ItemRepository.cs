using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Model;
using CanteenData.Views.ListViewModel;
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
		public ItemListViewModel GetAllItem()
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
			return newitem;  //massage item not found
		}
		public ItemViewModel AddItem(ItemViewModel newitem)
		{
			ItemViewModel justitem = new ItemViewModel();
			var result = _con.Unit.Where(test => test.ID == newitem.itemmodel.UnitId).FirstOrDefault();
			if (result == null)
			{
				return justitem;  //massage	   //massage	 (unit not found)
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
		public ItemViewModel EditItem(ItemViewModel edititem, int id)
		{
			ItemViewModel justitem = new ItemViewModel();
			var result = _con.Item.Where(test => test.ItemCode == id).FirstOrDefault();
			var unitid = _con.Unit.Where(test => test.ID == edititem.itemmodel.UnitId).FirstOrDefault();
			if (unitid == null)
			{
				return justitem;  //massage	 (unit not found)
			}
			if (result != null)
			{
				result.ItemName = edititem.itemmodel.ItemName;
				result.Image = edititem.itemmodel.Image;
				result.ReorderLevel = edititem.itemmodel.ReorderLevel;
				result.IsActive = edititem.itemmodel.IsActive;
				result.UnitId = edititem.itemmodel.UnitId;
				_con.Item.Update(result);
				_con.SaveChanges();
			}
			return edititem;  
		}
		public ItemViewModel DeleteItem(int id)
		{
			ItemViewModel justitem = new ItemViewModel();
			var result = _con.Item.Where(test => test.ItemCode == id).FirstOrDefault();
			if (result == null)
			{
				return justitem;  //massage	  item not found
			}
			result.IsActive = false;
			_con.Item.Update(result);
			_con.SaveChanges();
			justitem.itemmodel = result;
			return justitem;  //massage
		}
	}
}
