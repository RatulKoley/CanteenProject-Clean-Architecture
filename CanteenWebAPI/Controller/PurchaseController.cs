using CanteenCore.Interface;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanteenWebAPI.Controller
{
	[EnableCors("AllowOrigin")]
	[Route("[controller]")]
	[ApiController]
	public class PurchaseController : ControllerBase
	{
		private readonly IPurchaseService _service;
		public PurchaseController(IPurchaseService service)
		{
			_service = service;
		}
		[HttpPost("PurchaseList")]
		public ActionResult<PurchaseListViewModel> PurchaseList()
		{
			return _service.PurchaseList();
		}
		[HttpPost("GetPurchase/{id:int}")]
		public ActionResult<PurchaseViewModel> GetPurchase(int id)
		{
			return _service.GetPurchase(id);
		}
		[HttpPost("AddPurchase")]
		public ActionResult<PurchaseViewModel> AddPurchase(PurchaseViewModel newpurchase)
		{
			return _service.AddPurchase(newpurchase);
		}
		[HttpPut("UpdatePurchase/{id:int}")]
		public ActionResult<PurchaseViewModel> UpdatePurchase(PurchaseViewModel updatepurchase, int id)
		{
			return _service.UpdatePurchase(updatepurchase, id);
		}
		[HttpDelete("DeletePurchase/{id:int}")]
		public ActionResult<PurchaseViewModel> DeletePurchase(int id)
		{
			return _service.DeletePurchase(id);
		}
	}
}
