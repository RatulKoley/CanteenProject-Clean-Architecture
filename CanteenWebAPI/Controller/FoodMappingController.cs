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
	public class FoodMappingController : ControllerBase
	{
	  private readonly IFoodMappingService _service;
		public FoodMappingController(IFoodMappingService service)
		{
			_service = service;
		}
		[HttpPost("MappingList")]
		public ActionResult<FoodMappingListViewModel> MappingList()
		{
			return _service.MappingList();
		}
		[HttpPost("GetFoodMap/{id:int}")]
		public ActionResult<FoodMappingViewModel> GetFoodMap(int id)
		{
			return _service.GetFoodMap(id);
		}
		[HttpPost("AddFoodMap")]
		public ActionResult<FoodMappingViewModel> AddFoodMap(FoodMappingViewModel addfoodmap)
		{
			return _service.AddFoodMap(addfoodmap);
		}
		[HttpPut("UpdateFoodMap/{id:int}")]
		public ActionResult<FoodMappingViewModel> UpdateFoodMap(FoodMappingViewModel editfoodmap, int id)
		{
			return _service.UpdateFoodMap(editfoodmap, id);
		}
		[HttpDelete("DeleteFoodMap/{id:int}")]
		public ActionResult<FoodMappingViewModel> DeleteFoodMap(int id)
		{
			return _service.DeleteFoodMap(id);
		}

	}
}
