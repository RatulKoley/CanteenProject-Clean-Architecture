using CanteenCore.Interface;
using CanteenData.Interface;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Class
{
	public class StockService : IStockService
	{
		private readonly IStockRepository _stockrepo;
		public StockService(IStockRepository stockrepo)
		{
			_stockrepo = stockrepo;
		}
		public StockListViewModel GetList()
		{
			return _stockrepo.GetList();
		}
		public StockViewModel GetStock(int id)
		{
			return _stockrepo.GetStock(id);
		}
		public StockViewModel AddStock(StockViewModel newstock)
		{
			return _stockrepo.AddStock(newstock);
		}
		public StockViewModel UpdateStock(StockViewModel updatestock, int id)
		{
			return _stockrepo.UpdateStock(updatestock, id);
		}
		public StockViewModel DeleteStock(int id)
		{
			return _stockrepo.DeleteStock(id);
		}

	}
}
