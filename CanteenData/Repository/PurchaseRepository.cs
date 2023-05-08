using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Model;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Repository
{
	public class PurchaseRepository : IPurchaseRepository
	{
		private readonly DataContext con;
		public PurchaseRepository(DataContext con)
		{
			this.con = con;
		}
		public PurchaseListViewModel PurchaseList()
		{
			var PurchaseData = con.Purchase.Include(test => test.Item).Include(test => test.Supply).ToList() ;
			PurchaseListViewModel newpurchase = new PurchaseListViewModel();
			newpurchase.purchaselist = PurchaseData;
			return newpurchase;
		}
		public PurchaseViewModel GetPurchase(int id)
		{
			var result = con.Purchase.Include(test => test.Item).Include(test => test.Supply)
							.Where(test => test.PurchaseNo == id).FirstOrDefault() ;
			PurchaseViewModel newpurchase = new PurchaseViewModel();
			if (result != null)
			{
				newpurchase.purchasemodel = result;
			}
			return newpurchase; //massage
		}
		public PurchaseViewModel AddPurchase(PurchaseViewModel newpurchase)
		{
			PurchaseViewModel nullpurchase = new PurchaseViewModel();
			var itemcheck = con.Item.Where(test => test.ItemCode == newpurchase.purchasemodel.ItemId).FirstOrDefault();
			if (itemcheck == null)
			{
				return nullpurchase;//massage  (Item Not Available)
			}
			var supplycheck = con.Supply.Where(test => test.SupplyID == newpurchase.purchasemodel.SupplyId).FirstOrDefault();
			if (supplycheck == null)
			{
				return nullpurchase;//massage  (Supplier Not Available)
			}
			newpurchase.purchasemodel.PurchasedValue = newpurchase.purchasemodel.Price * newpurchase.purchasemodel.Quantity;
			Purchase p1 = new Purchase();
			p1.PurchasedDate = newpurchase.purchasemodel.PurchasedDate;
			p1.ItemId = newpurchase.purchasemodel.ItemId;
			p1.Price = newpurchase.purchasemodel.Price;
			p1.Quantity = newpurchase.purchasemodel.Quantity;
			p1.SupplyId = newpurchase.purchasemodel.SupplyId;
			p1.PurchasedValue = newpurchase.purchasemodel.PurchasedValue;
			con.Purchase.Add(p1);

			var checkstock = con.Stock.Where(test => test.ItemId == p1.ItemId).FirstOrDefault();
			if (checkstock == null)
			{
				var newstock = new Stock();
				newstock.ItemId = p1.ItemId;
				newstock.Qunatity = p1.Quantity;
				con.Stock.Add(newstock);
			}
			else
			{
				checkstock.Qunatity = checkstock.Qunatity + p1.Quantity;
				con.Stock.Update(checkstock);
			}
			con.SaveChanges();
			nullpurchase.purchasemodel = p1;
			return nullpurchase;
		}
		public PurchaseViewModel UpdatePurchase(PurchaseViewModel updatepurchase, int id)
		{
			PurchaseViewModel justpurchase = new PurchaseViewModel();
			var result = con.Purchase.Where(test => test.PurchaseNo == id).FirstOrDefault();
			if (result == null)
			{
				return justpurchase; // massage (Purchase Data Not Available)
			}
			var itemcheck = con.Item.Where(test => test.ItemCode == updatepurchase.purchasemodel.ItemId).FirstOrDefault();
			if (itemcheck == null)
			{
				return justpurchase;//massage  (Item Not Available)
			}
			var supplycheck = con.Supply.Where(test => test.SupplyID == updatepurchase.purchasemodel.SupplyId).FirstOrDefault();
			if (supplycheck == null)
			{
				return justpurchase;//massage  (Supplier Not Available)
			}

			updatepurchase.purchasemodel.PurchasedValue = updatepurchase.purchasemodel.Price * updatepurchase.purchasemodel.Quantity;
			result.PurchasedDate = updatepurchase.purchasemodel.PurchasedDate;
			result.ItemId = updatepurchase.purchasemodel.ItemId;
			result.Price = updatepurchase.purchasemodel.Price;
			result.Quantity = updatepurchase.purchasemodel.Quantity;
			result.SupplyId = updatepurchase.purchasemodel.SupplyId;
			result.PurchasedValue = updatepurchase.purchasemodel.PurchasedValue;
			con.Purchase.Update(result);

			var oldpurquant = con.Purchase.Where(test => test.PurchaseNo == result.PurchaseNo).FirstOrDefault();
			if (oldpurquant != null)
			{
				if (oldpurquant.Quantity != result.Quantity && oldpurquant.ItemId == result.ItemId)
				{
					var checkstock = con.Stock.Where(test => test.ItemId == oldpurquant.ItemId).FirstOrDefault();
					if (oldpurquant.Quantity > result.Quantity)
					{
						double updatequant = ((double)(oldpurquant.Quantity - result.Quantity));
						if (checkstock != null)
						{
							if (checkstock.Qunatity <= updatequant)
							{
								con.Stock.Remove(checkstock);
							}
							else
							{
								checkstock.Qunatity = checkstock.Qunatity - updatequant;
								con.Stock.Update(checkstock);
							}
						}
					}
					else if (oldpurquant.Quantity < result.Quantity)
					{
						double updatequant = ((double)(result.Quantity - oldpurquant.Quantity));
						if (checkstock != null)
						{
							checkstock.Qunatity = checkstock.Qunatity + updatequant;
							con.Stock.Update(checkstock);
						}
					}
					else if (checkstock == null)
					{
						var newstock = new Stock();
						newstock.ItemId = result.ItemId;
						newstock.Qunatity = result.Quantity;
						con.Stock.Add(newstock);
					}
				}
				if (oldpurquant.ItemId != result.ItemId)
				{
					var Removestock = con.Stock.Where(test => test.ItemId == oldpurquant.ItemId).FirstOrDefault();
					if (Removestock != null)
					{
						Removestock.Qunatity = Removestock.Qunatity - oldpurquant.Quantity;
						if (Removestock.Qunatity <= 0)
						{
							con.Stock.Remove(Removestock);
						}
						else
						{
							con.Stock.Update(Removestock);
						}
					}
					var updatestock = con.Stock.Where(test => test.ItemId == result.ItemId).FirstOrDefault();
					if (updatestock != null)
					{
						updatestock.Qunatity = updatestock.Qunatity + result.Quantity;
						con.Stock.Update(updatestock);
					}
					else
					{
						var newstock = new Stock();
						newstock.ItemId = result.ItemId;
						newstock.Qunatity = result.Quantity;
						con.Stock.Add(newstock);
					}
				}
			}
			con.SaveChanges();
			justpurchase.purchasemodel = result;
			return justpurchase;
		}

		public PurchaseViewModel DeletePurchase(int id)
		{
			PurchaseViewModel justpurchase = new PurchaseViewModel();
			var result = con.Purchase.Where(test => test.PurchaseNo == id).FirstOrDefault();
			if (result == null)
			{
				return justpurchase;  //massage	 (Purchase Data Not Found)
			}
			con.Purchase.Remove(result);

			var Removestock = con.Stock.Where(test => test.ItemId == result.ItemId).FirstOrDefault();
			if (Removestock != null)
			{
				Removestock.Qunatity = Removestock.Qunatity - result.Quantity;
				if (Removestock.Qunatity <= 0)
				{
					con.Stock.Remove(Removestock);
				}
				else
				{
					con.Stock.Update(Removestock);
				}
			}
			con.SaveChanges();
			justpurchase.purchasemodel = result;
			return justpurchase;   //massage
		}
	}

}

