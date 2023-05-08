using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Model;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Repository
{
	public class FoodMappingRepository : IFoodMappingRepository
	{
		private readonly DataContext con;
		public FoodMappingRepository(DataContext con)
		{
			this.con = con;
		}
		public FoodMappingListViewModel MappingList()
		{
			var newfoodmap = con.FoodMapping.Include(test => test.FoodMenu).ToList();
			FoodMappingListViewModel newfoodmaplist = new FoodMappingListViewModel();
			newfoodmaplist.foodmappinglist = newfoodmap;
			return newfoodmaplist;
		}
		public FoodMappingViewModel GetFoodMap(int id)
		{
			var result = con.FoodMapping.Include(test => test.FoodMenu).Where(test => test.MappingID == id).FirstOrDefault();
			FoodMappingViewModel newfoodmap = new FoodMappingViewModel();
			if (result != null)
			{
				newfoodmap.foodmappingmodel = result;
			}
			return newfoodmap; //massage 
		}
		public FoodMappingViewModel AddFoodMap(FoodMappingViewModel addfoodmap)
		{
			FoodMappingViewModel nullfoodmap = new FoodMappingViewModel();
			var foodcheck = con.FoodMenu.Where(test => test.FoodID == addfoodmap.foodmappingmodel.FoodID).FirstOrDefault();
			if (foodcheck == null)
			{
				return nullfoodmap;//massage	(Food Not Available)
			}
			var itemcheck = con.Item.Where(test => test.ItemCode == addfoodmap.foodmappingmodel.ItemId).FirstOrDefault();
			if (itemcheck == null)
			{
				return nullfoodmap;//massage	(Item Not Available)
			}
			FoodMapping F1 = new FoodMapping();
			F1.FoodID = addfoodmap.foodmappingmodel.FoodID;
			F1.FoodQuantity = addfoodmap.foodmappingmodel.FoodQuantity;
			F1.ItemId = addfoodmap.foodmappingmodel.ItemId;
			F1.ItemQuantity = addfoodmap.foodmappingmodel.ItemQuantity;
			F1.Active = true;
			con.FoodMapping.Add(F1);
			con.SaveChanges();
			nullfoodmap.foodmappingmodel = F1;
			return nullfoodmap;
		}
		public FoodMappingViewModel UpdateFoodMap(FoodMappingViewModel editfoodmap, int id)
		{
			FoodMappingViewModel nullfoodmap = new FoodMappingViewModel();
			var foodcheck = con.FoodMenu.Where(test => test.FoodID == editfoodmap.foodmappingmodel.FoodID).FirstOrDefault();
			if (foodcheck == null)
			{
				return nullfoodmap;//massage	(Food Not Available)
			}
			var itemcheck = con.Item.Where(test => test.ItemCode == editfoodmap.foodmappingmodel.ItemId).FirstOrDefault();
			if (itemcheck == null)
			{
				return nullfoodmap;//massage	(Item Not Available)
			}
			var mapresult = con.FoodMapping.Where(test => test.MappingID == id).FirstOrDefault();
			if (mapresult != null)
			{
				mapresult.FoodQuantity = editfoodmap.foodmappingmodel.FoodQuantity;
				mapresult.ItemId = editfoodmap.foodmappingmodel.ItemId;
				mapresult.ItemQuantity = editfoodmap.foodmappingmodel.ItemQuantity;
				mapresult.Active = editfoodmap.foodmappingmodel.Active;
				con.FoodMapping.Update(mapresult);
				con.SaveChanges();
				nullfoodmap.foodmappingmodel = mapresult;
			}
			return nullfoodmap;
		}
		public FoodMappingViewModel DeleteFoodMap(int id)
		{
			FoodMappingViewModel nullfoodmap = new FoodMappingViewModel();
			var result = con.FoodMapping.Where(test => test.MappingID == id).FirstOrDefault();
			if (result == null)
			{
				return nullfoodmap;  //massage	 (Mapping Data Not Available)
			}
			result.Active = false;
			con.FoodMapping.Update(result);
			con.SaveChanges();
			nullfoodmap.foodmappingmodel = result;
			return nullfoodmap;   //massage
		}
	}
}
