using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Model;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Repository
{
	public class SupplyRepository : ISupplyRepository
	{
		private readonly DataContext con;
		public SupplyRepository(DataContext con)
		{
			this.con = con;
		}
		public SupplyListViewModel SupplyList()
		{
			var SupplyData = con.Supply.Include(test => test.Purchase).ToList();
			SupplyListViewModel newsupplier = new SupplyListViewModel();
			newsupplier.supplylist = SupplyData;
			return newsupplier;
		}
		public SupplyViewModel GetSupply(int id)
		{
			var result = con.Supply.Include(test => test.Purchase).Where(test => test.SupplyID == id).FirstOrDefault();
			SupplyViewModel newsupplier = new SupplyViewModel();
			if (result != null)
			{
				newsupplier.supplymodel = result;
			}
			return newsupplier; //massage 
		}
		public SupplyViewModel AddSupply(SupplyViewModel newsupply)
		{
			SupplyViewModel nullsupply = new SupplyViewModel();
			var result = con.Supply.Where(test => test.SupplyID == newsupply.supplymodel.SupplyID).FirstOrDefault();
			if (result != null)
			{
				return nullsupply;//massage
			}
			Supply S1 = new Supply();
			S1.SupplierName = newsupply.supplymodel.SupplierName;
			S1.IsActive = true;
			con.Supply.Add(S1);
			con.SaveChanges();
			nullsupply.supplymodel = S1;
			return nullsupply;
		}
		public SupplyViewModel UpdateSupply(SupplyViewModel updatesupply, int id)
		{
			SupplyViewModel justsupply = new SupplyViewModel();
			var result = con.Supply.Where(test => test.SupplyID == id).FirstOrDefault();
			if (result != null)
			{
				result.SupplierName = updatesupply.supplymodel.SupplierName;
				result.IsActive = updatesupply.supplymodel.IsActive;
				con.Supply.Update(result);
				con.SaveChanges();
				justsupply.supplymodel = result;
			}
			return justsupply;
		}
		public SupplyViewModel DeleteSupply(int id)
		{
			SupplyViewModel justsupply = new SupplyViewModel();
			var result = con.Supply.Where(test => test.SupplyID == id).FirstOrDefault();
			if (result == null)
			{
				return justsupply;  //massage
			}
			result.IsActive = false;
			con.Supply.Update(result);
			con.SaveChanges();
			return justsupply;   //massage
		}

	}
}
