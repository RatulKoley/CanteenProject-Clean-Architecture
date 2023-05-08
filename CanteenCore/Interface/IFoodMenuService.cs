using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Interface
{
	public interface IFoodMenuService
	{
		public FoodMenuListViewModel GetList();
		public FoodMenuViewModel GetFood(int id);
		public FoodMenuViewModel AddFood(FoodMenuViewModel newfood);
		public FoodMenuViewModel EditFood(FoodMenuViewModel updatefood, int id);
		public FoodMenuViewModel DeleteFood(int id);
	}
}
