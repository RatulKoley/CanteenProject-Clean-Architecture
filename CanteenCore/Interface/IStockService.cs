using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Interface
{
	public interface IStockService
	{
		public StockListViewModel GetList();
		public StockViewModel GetStock(int id);
		public StockViewModel AddStock(StockViewModel newstock);
		public StockViewModel UpdateStock(StockViewModel updatestock, int id);
		public StockViewModel DeleteStock(int id);
	}
}
