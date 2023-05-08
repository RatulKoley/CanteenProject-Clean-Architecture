using CanteenCore.Interface;
using CanteenData.Interface;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;

namespace CanteenCore.Class
{
	public class FoodMenuService : IFoodMenuService
	{
		private readonly IFoodMenuRepository _foodmenurepo;
		public FoodMenuService (IFoodMenuRepository foodmenurepo)
		{
			_foodmenurepo = foodmenurepo;
		}
		public FoodMenuListViewModel GetList()
		{
			return _foodmenurepo.GetList();
		}
		public FoodMenuViewModel GetFood(int id)
		{
			return _foodmenurepo.GetFood(id);
		}
		public FoodMenuViewModel AddFood(FoodMenuViewModel newfood)
		{
			return _foodmenurepo.AddFood(newfood);
		}
		public FoodMenuViewModel EditFood(FoodMenuViewModel updatefood, int id)
		{
			return _foodmenurepo.EditFood(updatefood, id);
		}
		public FoodMenuViewModel DeleteFood(int id)
		{
			return _foodmenurepo.DeleteFood(id);
		}
	}
}
