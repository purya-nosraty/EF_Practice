using Microsoft.EntityFrameworkCore;

namespace Models_Attributes;

public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
	public DatabaseContext() : base()
	{
		Database.EnsureCreated();
	}

	public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }
	public Microsoft.EntityFrameworkCore.DbSet<TeacherTable> Table_Category { get; set; }

	protected override void OnConfiguring(Microsoft.EntityFrameworkCore
		.DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString =
			"Server=.;Database=Models_Attributes;MultipleActiveResultSets=true;User ID=sa;Password=123;TrustServerCertificate=true;";

		optionsBuilder.UseSqlServer(connectionString: connectionString);
	}
}
