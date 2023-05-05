using CanteenData.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddCors(_ =>
{
	_.AddPolicy("AllowOrigin", builder =>
	{
		builder.AllowAnyHeader()
			.AllowAnyMethod()
			.SetIsOriginAllowedToAllowWildcardSubdomains()
			.SetIsOriginAllowed(origin => true)
			.AllowCredentials();
	});
});
builder.Services.AddDbContext<DataContext>(test =>
{
	test.UseSqlServer(builder.Configuration.GetConnectionString("dbcon"));
	test.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(options => options.AllowAnyOrigin());
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseHttpsRedirection();

app.Run();
