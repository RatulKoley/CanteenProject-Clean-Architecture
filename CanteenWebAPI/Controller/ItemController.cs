using CanteenCore.Interface;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CanteenWebAPI.Controller
{
	[EnableCors("AllowOrigin")]
	[Route("[controller]")]
	[ApiController]
	public class ItemController : ControllerBase
	{
		private readonly IItemService _service;
		public ItemController(IItemService service)
		{
			_service = service;
		}
		[HttpPost("GetList")]
		public ActionResult<ItemListViewModel> GetAllItem(ItemListViewModel objModel)
		{
			return _service.GetAllItem(objModel);
		}
		[HttpPost("GetItem/{id:int}")]
		public ActionResult<ItemViewModel> GetItemByID(int id)
		{
			return _service.GetItemByID(id);
		}
		[HttpPost("AddItem")]
		public ActionResult<ItemViewModel> AddItem(ItemViewModel newitem)
		{
			return _service.AddItem(newitem);
		}
		[HttpPut("EditItem")]
		public ActionResult<ItemViewModel> EditItem(ItemViewModel edititem)
		{
			return _service.EditItem(edititem);
		}
		[HttpDelete("DeleteItem/{id:int}")]
		public ActionResult<ItemViewModel> DeleteItem(int id)
		{
			return _service.DeleteItem(id);
		}
	}
}
