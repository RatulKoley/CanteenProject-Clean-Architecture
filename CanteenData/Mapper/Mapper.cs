using AutoMapper;
using CanteenData.DTO;
using CanteenData.Model;

namespace CanteenData.Mapper
{
	public class Mapper : Profile
	{
		public Mapper()
		{
			CreateMap<ItemDTO, Item>().ReverseMap();
			CreateMap<StockDTO, Stock>().ReverseMap();
			CreateMap<SupplyDTO, Supply>().ReverseMap();
			CreateMap<PurchaseDTO, Purchase>().ReverseMap();
			CreateMap<KitchenFoodDTO, KitchenFood>().ReverseMap();
			CreateMap<FoodMapppingDTO, FoodMapping>().ReverseMap();
			CreateMap<FoodMenuDTO, FoodMenu>().ReverseMap();
			CreateMap<SalesDTO, Sales>().ReverseMap();
			CreateMap<UnitDTO, Unit>().ReverseMap();
		}
	}
}
