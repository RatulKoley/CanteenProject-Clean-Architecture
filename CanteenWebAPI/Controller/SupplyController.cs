using CanteenCore.Interface;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanteenWebAPI.Controller
{
	[EnableCors("AllowOrigin")]
	[Route("api/[controller]")]
	[ApiController]
	public class SupplyController : ControllerBase
	{
		private readonly ISupplyService _service;
		public SupplyController(ISupplyService service)
		{
			_service = service;
		}
		[HttpPost("SupplyList")]
		public ActionResult<SupplyListViewModel> SupplyList()
		{
			return _service.SupplyList();
		}
		[HttpPost("GetSupply/{id:int}")]
		public ActionResult<SupplyViewModel> GetSupply(int id)
		{
			return _service.GetSupply(id);
		}
		[HttpPost("AddSupply")]
		public ActionResult<SupplyViewModel> AddSupply(SupplyViewModel newsupply)
		{
			return _service.AddSupply(newsupply);
		}
		[HttpPut("UpdateSupply/{id:int}")]
		public ActionResult<SupplyViewModel> UpdateSupply(SupplyViewModel updatesupply, int id)
		{
			return _service.UpdateSupply(updatesupply, id);
		}
		[HttpDelete("DeleteSupply/{id:int}")]
		public ActionResult<SupplyViewModel> DeleteSupply(int id)
		{
			return _service.DeleteSupply(id);
		}
	}
}
