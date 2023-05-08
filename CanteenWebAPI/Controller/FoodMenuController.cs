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
	public class FoodMenuController : ControllerBase
	{
		private readonly IFoodMenuService _service;
		public FoodMenuController(IFoodMenuService service)
		{
			_service = service;
		}
		[HttpPost("GetList")]
		public ActionResult<FoodMenuListViewModel> GetList()
		{
			return _service.GetList();
		}
		[HttpPost("GetFood/{id:int}")]
		public ActionResult<FoodMenuViewModel> GetFood(int id)
		{
			return _service.GetFood(id);
		}
		[HttpPost("AddFood")]
		public ActionResult<FoodMenuViewModel> AddFood(FoodMenuViewModel newfood)
		{
			return _service.AddFood(newfood);
		}
		[HttpPut("EditFood/{id:int}")]
		public ActionResult<FoodMenuViewModel> EditFood(FoodMenuViewModel updatefood, int id)
		{
			return _service.EditFood(updatefood, id);
		}
		[HttpDelete("DeleteFood/{id:int}")]
		public ActionResult<FoodMenuViewModel> DeleteFood(int id)
		{
			return _service.DeleteFood(id);
		}
	}
}
