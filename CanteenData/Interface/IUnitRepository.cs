using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;

namespace CanteenData.Interface
{
	public interface IUnitRepository
	{
		public UnitListViewModel GetAllUnit(UnitListViewModel objModel);
		public UnitViewModel GetUnitByID(int id);
		public UnitViewModel AddUnit(UnitViewModel newunit);
		public UnitViewModel EditUnit(UnitViewModel editunit, int id);
		public UnitViewModel DeleteUnit(int id);

	}
}
