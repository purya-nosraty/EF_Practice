using Models_Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using System;

namespace Learning_Attributes;

internal static class Program : Object
{
	static Program()
	{
	}

	private static async System.Threading.Tasks.Task Main()
	{
		await CreateCategoryAsync();
	}
	private static async System.Threading.Tasks.Task CreateCategoryAsync()
	{
		Models_Attributes.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new Models_Attributes.DatabaseContext();

			var category = new Models_Attributes.Category(name: "Pouria", nationalCode: "1231234564")
			{
				Description = "Description",
				Ordering = 10,
			};

			var id = category.Key;

			var entityEntry =
				await
				databaseContext.AddAsync(entity: category);

			var affectedRows =
					await
					databaseContext.SaveChangesAsync();

			System.Console.WriteLine
				(value: $"{nameof(affectedRows)}: {affectedRows}");

			//==========================================================

			var teacherTable =
					new Models_Attributes.TeacherTable(name: "Dariush");

			var teacherId = teacherTable.Id;

			var code = teacherTable.Code;

			var teacherEntity =
				await
				databaseContext.AddAsync(entity: teacherTable);

			var techerRows =
				await
				databaseContext.SaveChangesAsync();

			System.Console.WriteLine(value: $"{nameof(techerRows)}: {techerRows}");
		}
		catch (System.Exception ex)
		{
			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			await databaseContext!.DisposeAsync();
		}
	}
}