using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Model;
using CanteenData.ViewModel.ViewModelList;
using CanteenData.Views.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Repository
{
	public class FoodMenuRepository : IFoodMenuRepository
	{
		private readonly DataContext con;
		public FoodMenuRepository(DataContext con)
		{
			this.con = con;
		}
		public FoodMenuListViewModel GetList()
		{
			var FoodMenuData = con.FoodMenu.Include(test => test.FoodMapping).Include(test => test.KitchenFood).ToList();
			FoodMenuListViewModel newfood = new FoodMenuListViewModel();
			newfood.foodmenulist = FoodMenuData;
			return newfood;
		}
		public FoodMenuViewModel GetFood(int id)
		{
			var result = con.FoodMenu.Include(test => test.FoodMapping).Include(test => test.KitchenFood)
						.Where(test => test.FoodID == id).FirstOrDefault();
			FoodMenuViewModel newfood = new FoodMenuViewModel();
			if (result != null)
			{
				newfood.foodmenumodel = result;
			}
			return newfood; //massage
		}
		public FoodMenuViewModel AddFood(FoodMenuViewModel newfood)
		{
			FoodMenuViewModel newfooditem = new FoodMenuViewModel();
			var result = con.FoodMenu.Where(test => test.FoodID == newfood.foodmenumodel.FoodID).FirstOrDefault();
			if (result != null)
			{
				return newfooditem;//massage
			}
			FoodMenu F1 = new FoodMenu();
			F1.FoodName = newfood.foodmenumodel.FoodName ;
			F1.Price = newfood.foodmenumodel.Price;
			F1.IsActive = true;
			con.FoodMenu.Add(F1);
			con.SaveChanges();
			newfooditem.foodmenumodel = F1;
			return newfooditem;
		}
		public FoodMenuViewModel EditFood(FoodMenuViewModel updatefood, int id)
		{
			FoodMenuViewModel justfood = new FoodMenuViewModel();
			var result = con.FoodMenu.Where(test => test.FoodID == id).FirstOrDefault();
			if (result != null)
			{
				result.FoodName = updatefood.foodmenumodel.FoodName;
				result.Price = updatefood.foodmenumodel.Price;
				result.IsActive = updatefood.foodmenumodel.IsActive;
				con.FoodMenu.Update(result);
				con.SaveChanges();
				justfood.foodmenumodel = result;
			}
			return justfood;
		}
		public FoodMenuViewModel DeleteFood(int id)
		{
			FoodMenuViewModel justfood = new FoodMenuViewModel();
			var result = con.FoodMenu.Where(test => test.FoodID == id).FirstOrDefault();
			if (result == null)
			{
				return justfood;  //massage
			}
			result.IsActive = false;
			con.FoodMenu.Update(result);
			con.SaveChanges();
			return justfood;   //massage
		}
	}
}
