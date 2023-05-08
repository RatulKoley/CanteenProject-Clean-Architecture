using AutoMapper;
using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Model;
using CanteenData.Views.ListViewModel;
using CanteenData.Views.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CanteenData.Repository
{
	public class UnitRepository : IUnitRepository
	{
		private readonly DataContext con;
		private readonly IMapper imap;
		public UnitRepository(DataContext con)
		{
			//this.con = DBContext.Create();
			this.con = con;
		}
		public UnitListViewModel GetAllUnit()
		{
			var UnitData = con.Unit.Include(test => test.Item).ToList();
			UnitListViewModel allunit = new UnitListViewModel();
			allunit.unitlist = UnitData;
			//unit.unit = imap.Map<List<UnitDTO>>(UnitData);
			return allunit;
		}
		public UnitViewModel GetUnitByID(int id)
		{
			var result = con.Unit.Where(test => test.ID == id).Include(test => test.Item).FirstOrDefault();
			UnitViewModel unit = new UnitViewModel();
			if (result != null)
			{
				unit.unitmodel = result;
			}
			return (unit);

		}
		public UnitViewModel AddUnit(UnitViewModel newunit)
		{
			//var newone = imap.Map<Unit>(newunit);
			UnitViewModel showunit = new UnitViewModel();
			Unit u1 = new Unit();
			u1.UnitName = newunit.unitmodel.UnitName;
			u1.IsActive = true;
			con.Unit.Add(u1);
			con.SaveChanges();
			showunit.unitmodel = u1;
			return showunit;
		}

		public UnitViewModel EditUnit(UnitViewModel editunit, int id)
		{
			UnitViewModel editone = new UnitViewModel();
			var result = con.Unit.Where(test => test.ID == id).FirstOrDefault();
			if (result != null)
			{
				result.UnitName = editunit.unitmodel.UnitName;
				result.IsActive = editunit.unitmodel.IsActive;
				con.Unit.Update(result);
				con.SaveChanges();
				editone.unitmodel = result;
			}
			return editunit;
		}
		public UnitViewModel DeleteUnit(int id)
		{
			UnitViewModel unit = new UnitViewModel();
			var result = con.Unit.Where(test => test.ID == id).FirstOrDefault();
			//con.Unit.Remove(result);
			if (result != null)
			{
				result.IsActive = false;
				con.Unit.Update(result);
				con.SaveChanges();
				unit.unitmodel = result;
			}
			return unit;
		}
	}
}
