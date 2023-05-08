using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;

namespace CanteenData.Interface
{
	public interface IFoodMappingRepository
	{
		public FoodMappingListViewModel MappingList();
		public FoodMappingViewModel GetFoodMap(int id);
		public FoodMappingViewModel AddFoodMap(FoodMappingViewModel addfoodmap);
		public FoodMappingViewModel UpdateFoodMap(FoodMappingViewModel editfoodmap, int id)	;
		public FoodMappingViewModel DeleteFoodMap(int id);
	}
}
