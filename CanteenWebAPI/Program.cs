using CanteenCore.Class;
using CanteenCore.Interface;
using CanteenData.Context;
using CanteenData.Interface;
using CanteenData.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddCors(_ =>
{
	_.AddPolicy("AllowOrigin", builder =>
	{
		builder.WithOrigins("*")
			.AllowAnyHeader()
		   .AllowAnyMethod()
		   .SetIsOriginAllowedToAllowWildcardSubdomains();
	});
});

//if (builder.Configuration["dbtype"] == "sqlserver")
//{
//	builder.Services.AddScoped<IDBContext, DbContext>(serviceprovider =>
//  new DbContext(builder.Configuration["connectionstringtemplate"]));
//}
builder.Services.AddDbContext<DataContext>(test =>
	{
		test.UseSqlServer(builder.Configuration.GetConnectionString("dbcon"));
		test.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	});

builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<IFoodMappingService, FoodMappingService>();
builder.Services.AddScoped<IFoodMappingRepository, FoodMappingRepository>();

builder.Services.AddScoped<IFoodMenuService, FoodMenuService>();
builder.Services.AddScoped<IFoodMenuRepository, FoodMenuRepository>();

builder.Services.AddScoped<IKitchenFoodService, KitchenFoodService>();
builder.Services.AddScoped<IKitchenFoodRepository, KitchenFoodRepository>();

builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();

builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ISalesService, SalesService>();

builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();

builder.Services.AddScoped<ISupplyService, SupplyService>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseHttpsRedirection();
	app.UseRouting();
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseCors(options => options.AllowAnyOrigin());
	app.UseEndpoints(endpoints => endpoints.MapControllers());
}


app.Run();

//public class Startup
//{
//	private IConfiguration configur { get; }
//	public Startup(IConfiguration config)
//	{
//		this.configur = config;
//	}
//	public void CofigureServices(IServiceCollection service)
//	{
//		if (configur["dbtype"] == "sqlserver")
//	{
//		service.AddScoped<IDBContext, DbContext>(serviceprovider =>
//	  new DbContext(configur["connectionstringtemplate"]));
//	}
//	}
//}