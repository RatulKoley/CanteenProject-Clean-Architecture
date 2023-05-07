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
	public class UnitController : ControllerBase
	{
		private readonly IUnitService _iunitservice;

		public UnitController(IUnitService iunitservice)
		{
			_iunitservice = iunitservice;
		}


		[HttpPost("GetList")]
		public ActionResult<UnitListViewModel> GetAllUnit(UnitListViewModel objModel)
		{
			return _iunitservice.GetAllUnit(objModel);
		}
		[HttpPost("GetList/{id:int}")]
		public ActionResult<UnitViewModel> GetUnitByID(int id)
		{
			return _iunitservice.GetUnitByID(id);
		}
		[HttpPost("AddUnit")]
		public ActionResult<UnitViewModel> AddUnit(UnitViewModel newunit)
		{
			return _iunitservice.AddUnit(newunit);
		}
		[HttpPut("EditUnit/{id:int}")]
		public ActionResult<UnitViewModel> EditUnit(UnitViewModel editunit, int id)
		{
			return _iunitservice.EditUnit(editunit, id);
		}
		[HttpDelete("DeleteUnit/{id:int}")]
		public ActionResult<UnitViewModel> DeleteUnit(int id)
		{
			return _iunitservice.DeleteUnit(id);
		}


	}
}
