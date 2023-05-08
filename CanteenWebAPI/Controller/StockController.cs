using CanteenCore.Interface;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanteenWebAPI.Controller
{
	[EnableCors("AllowOrigin")]
	[Route("[controller]")]
	[ApiController]
	public class StockController : ControllerBase
	{
		private readonly IStockService _service;
		public StockController(IStockService service)
		{
			_service = service;
		}
		[HttpPost("ListStock")]
		public ActionResult<StockListViewModel> GetList()
		{
			return _service.GetList();
		}
		[HttpPost("GetStock/{id:int}")]
		public ActionResult<StockViewModel> GetStock(int id)
		{
			return _service.GetStock(id);
		}
		[HttpPost("AddStock")]
		public ActionResult<StockViewModel> AddStock(StockViewModel newstock)
		{
			return _service.AddStock(newstock);
		}
		[HttpPut("UpdateStock/{id:int}")]
		public ActionResult<StockViewModel> UpdateStock(StockViewModel updatestock,int id)
		{
			return _service.UpdateStock(updatestock, id);
		}
		[HttpDelete("DeleteStock/{id:int}")]
		public ActionResult<StockViewModel> DeleteStock(int id)
		{
			return _service.DeleteStock(id);
		}
	}
}
