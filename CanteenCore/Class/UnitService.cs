using CanteenCore.Interface;
using CanteenData.Interface;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Class
{
	public class UnitService : IUnitService
	{
		private readonly IUnitRepository IunitRepo;
		public UnitService(IUnitRepository IunitRepo)
		{
			this.IunitRepo = IunitRepo;
		}
		public UnitListViewModel GetAllUnit()
		{
			return this.IunitRepo.GetAllUnit();
		}
		public UnitViewModel GetUnitByID(int id)
		{
			return this.IunitRepo.GetUnitByID(id);
		}
		public UnitViewModel AddUnit(UnitViewModel newunit)
		{
			return this.IunitRepo.AddUnit(newunit);
		}
		public UnitViewModel EditUnit(UnitViewModel editunit, int id)
		{
			return this.IunitRepo.EditUnit(editunit, id);
		}
		public UnitViewModel DeleteUnit(int id)
		{
			return this.IunitRepo.DeleteUnit(id);
		}
	}
}
