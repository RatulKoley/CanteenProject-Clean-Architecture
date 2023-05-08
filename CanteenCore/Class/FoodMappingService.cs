using CanteenCore.Interface;
using CanteenData.Interface;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Class
{
	public class FoodMappingService : IFoodMappingService
	{
		private readonly IFoodMappingRepository _foodmaprepo;
		public FoodMappingService(IFoodMappingRepository foodmaprepo)
		{
			_foodmaprepo = foodmaprepo;
		}
		public FoodMappingListViewModel MappingList()
		{
			return _foodmaprepo.MappingList();
		}
		public FoodMappingViewModel GetFoodMap(int id)
		{
			return _foodmaprepo.GetFoodMap(id);
		}
	   public FoodMappingViewModel AddFoodMap(FoodMappingViewModel addfoodmap)
		{
			return _foodmaprepo.AddFoodMap(addfoodmap);
		}
		public FoodMappingViewModel UpdateFoodMap(FoodMappingViewModel editfoodmap, int id)
		{
			return _foodmaprepo.UpdateFoodMap(editfoodmap, id);
		}
		public FoodMappingViewModel DeleteFoodMap(int id)
		{
			return _foodmaprepo.DeleteFoodMap(id);
		}

	}
}
