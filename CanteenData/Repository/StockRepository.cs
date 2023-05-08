using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Model;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Repository
{
	public class StockRepository : IStockRepository
	{
		private readonly DataContext con;
		public StockRepository(DataContext con)
		{
			this.con = con;
		}
		public StockListViewModel GetList()
		{
			var StockData = con.Stock.Include(test => test.Item).ToList();
			StockListViewModel newstock = new StockListViewModel();
			newstock.stocklist = StockData;
			return newstock;
		}
		public StockViewModel GetStock(int id)
		{
			var result = con.Stock.Include(test => test.Item).Where(test => test.StockID == id).FirstOrDefault();
			StockViewModel newstock = new StockViewModel();
			if (result != null)
			{
				newstock.stockmodel = result;
			}
			return newstock; //massage (Stock Dont Exist)
		}
		public StockViewModel AddStock(StockViewModel newstock)
		{
			StockViewModel nullstock = new StockViewModel();
			var itemcheck = con.Item.Where(test => test.ItemCode == newstock.stockmodel.ItemId).FirstOrDefault();
			if(itemcheck == null)
			{
				return nullstock; //massage	  (item dont exist)
			}
			var result = con.Stock.Where(test => test.ItemId == newstock.stockmodel.ItemId).FirstOrDefault();
			if (result == null)
			{
				Stock S1 = new Stock();
				S1.ItemId = newstock.stockmodel.ItemId;
				S1.Qunatity = newstock.stockmodel.Qunatity;
				con.Stock.Add(S1);
				con.SaveChanges();
				nullstock.stockmodel = S1;
			}
			return nullstock; //massage (Item stock exist use update)
		}
		 public StockViewModel UpdateStock(StockViewModel updatestock, int id)
		{
			StockViewModel juststock = new StockViewModel();
			var result = con.Stock.Where(test => test.StockID == id).FirstOrDefault();
			var itemid = con.Item.Where(test => test.ItemCode == updatestock.stockmodel.ItemId).FirstOrDefault();
			if (itemid == null)
			{
				return juststock;  //massage  (item dont exist)
			}
			var stockcheck = con.Stock.Where(test => test.ItemId == updatestock.stockmodel.ItemId).FirstOrDefault();
			if (result != null && stockcheck == null)
			{
				result.ItemId = updatestock.stockmodel.ItemId;
				result.Qunatity = updatestock.stockmodel.Qunatity;
				con.Stock.Update(result);
				con.SaveChanges();
				juststock.stockmodel = result;
			}
			return juststock; //massage stock already exist for this item elsewhere
		}
		 public StockViewModel DeleteStock(int id)
		{
			StockViewModel juststock = new StockViewModel();
			var result = con.Stock.Where(test => test.StockID == id).FirstOrDefault();
			if (result == null)
			{
				return juststock;  //massage
			}
			con.Stock.Remove(result);
			con.SaveChanges();
			return juststock;   //massage
		}

	}
}
