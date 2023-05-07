using CanteenData.Interface;

namespace CanteenData.Context
{
	public class DBContext : IDBContext
	{
		//private readonly string connectionstringtemplate;
		//public string TenantName { get; set; }
		//public DBContext(string connectionstringtemplate)
		//{
		//	this.connectionstringtemplate = connectionstringtemplate;
		//}

		//public DataContext Create()
		//{
		//	DataContext context = null;
		//	if (!string.IsNullOrWhiteSpace(this.TenantName))
		//	{
		//		var conbuild = new DbContextOptionsBuilder();
		//		conbuild.UseSqlServer(this.connectionstringtemplate.Replace("{tenant}", this.TenantName));
		//		context = new DataContext(conbuild.Options);
		//		context.Database.Migrate();
		//	}
		//	return context;
		//}
		//public DataContext Create(string TenantName)
		//{
		//	DataContext context = null;
		//	if (!string.IsNullOrWhiteSpace(TenantName))
		//	{
		//		var conbuild = new DbContextOptionsBuilder();
		//		conbuild.UseSqlServer(this.connectionstringtemplate.Replace("{tenant}", TenantName));
		//		context = new DataContext(conbuild.Options);
		//		context.Database.Migrate();
		//	}
		//	return context;
		//}
	}
}
