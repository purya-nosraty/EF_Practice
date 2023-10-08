using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Persistence;
using System.Linq;

namespace Application;
internal static class Program : object
{
	static Program()
	{
	}

	private static async System.Threading.Tasks.Task Main()
	{
		await CreateCategoryAsync();
		await DisplayCategoriesAsync();
		await UpdateCategoryAsync();
		await DeleteFirstCategoryAsync();
	}

	//private static void CreateCategory()
	//{
	//	
	//	var databaseContext = new Persistence.DatabaseContext();

	//	//var category = new Persistence.Category();
	//	//category.Name = "Test";
	//	var category = new Persistence.Category
	//	{
	//		Name = "Test",
	//	};

	//	databaseContext.Add(entity: category);

	//	databaseContext.SaveChanges();
	//}

	//==================================================

	////"using" uses for disposing methods which are disposable:

	//using (var databaseContext = new Persistence.DatabaseContext())
	//{
	//	var category = new Persistence.Category
	//	{
	//		Name = "Test",
	//	};

	//	databaseContext.Add(entity: category);

	//	databaseContext.SaveChanges();
	//}

	//==================================================

	//FOR USING THE ASYNC METHODS WE HAVE TO:
	//1) WRITE "Async" AT THE END OF FUNCTION'S NAME
	//2) WRITE "System.Threading.Tasks.Task" BEFORE FUNCTION'S NAME
	//3) WRITE "await" BEFORE FUNCTION'S NAME WHEN WE WANT TO USE THE FUNCTION

	//==================================================

	/// <summary>
	/// Create
	/// </summary>
	/// <returns></returns>
	private static async System.Threading.Tasks.Task CreateCategoryAsync()
	{
		Persistence.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new Persistence.DatabaseContext();

			var category = new Persistence.Category
			{
				Name = "test",
			};

			//databaseContext.Categories.Add(entity: category);
			var entityEntry =
				await
				databaseContext.AddAsync(entity: category);

			var affectedRows =
				await
				databaseContext.SaveChangesAsync();

			System.Console.WriteLine
				(value: $"{nameof(affectedRows)}: {affectedRows}");
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
	//***************************************************************************

	/// <summary>
	/// Fetch Data
	/// </summary>
	/// <returns></returns>
	private static async System.Threading.Tasks.Task DisplayCategoriesAsync()
	{
		Persistence.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new Persistence.DatabaseContext();

			//SELECT * FROM CATEGORIES:

			//var categories = databaseContext.Categories.ToList();
			//var categories = await databaseContext.Categories.ToListAsync();

			//==================================================

			//SELECT * FROM CATEGORIES WHERE ID < 3:

			//var categories =
			//	await
			//	databaseContext.Categories
			//	.Where(current => current.Id < 3)
			//	.ToListAsync()
			//	;

			//==================================================

			//SELECT * FROM CATEGORIES WHERE ID < 3 ORDER BY ID DESC:

			//var categories =
			//	await
			//	databaseContext.Categories
			//	.Where(current => current.Id < 3)
			//	.OrderByDescending(current => current.Id)
			//	.ToListAsync()
			//	;

			//foreach (var item in categories)
			//{
			//	string? message =
			//		$"Name: {item.Name} | Id: {item.Id}";

			//	System.Console.WriteLine(value: message);
			//}

			//==================================================

			string? name = "Te";

			if (name != null)
			{
				var categories =
					await
					databaseContext.Categories
					.Where(current => current.Name!.ToLower()
					.StartsWith(name.ToLower()))
					.ToListAsync();

				foreach (var item in categories)
				{
					string message =
						$"Name: {item.Name} | Id: {item.Id}";

					System.Console.WriteLine(value: message);
				}
			}
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

	//***************************************************************************

	/// <summary>
	/// Update
	/// </summary>
	///<returns></returns>
	private static async System.Threading.Tasks.Task UpdateCategoryAsync()
	{
		Persistence.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new Persistence.DatabaseContext();

			//var category =
			//	await
			//	databaseContext.Categories
			//	.Where(current => current.Id < 3)
			//	.OrderBy(current => current.Id)
			//	.FirstOrDefaultAsync();

			//if (category == null)
			//{
			//	System.Console.WriteLine
			//		(value: "There is no Category with this name ");

			//	return;
			//}

			var categories =
				await
				databaseContext.Categories
				.Where(current => current.Name == "popo")
				.ToListAsync();

			foreach (var item in categories)
			{
				item.Name = "xoxo";

				System.Console.WriteLine
					(value: $"Name: {item.Name} | Id: {item.Id}");
			}

			var affectedRows =
				await databaseContext.SaveChangesAsync();
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

	//***************************************************************************

	/// <summary>
	/// Delete
	/// </summary>
	/// <returns></returns>
	private static async System.Threading.Tasks.Task DeleteFirstCategoryAsync()
	{
		Persistence.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new Persistence.DatabaseContext();

			var category =
				await
				databaseContext.Categories
				.Where(current => current.Id <= 6)
				.FirstOrDefaultAsync();

			if (category == null)
			{
				System.Console.WriteLine(value: "The Category does not exist!");

				return;
			}

			var entityEntry =
				databaseContext.Remove(entity: category);

			var affectedRows =
				await databaseContext.SaveChangesAsync();
		}
		catch (System.Exception ex)
		{
			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			databaseContext?.Dispose();
		}
	}

	//***************************************************************************

	private static async System.Threading.Tasks.Task DeleteAllCategoriesAsync()
	{
		Persistence.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new Persistence.DatabaseContext();

			var categories =
				await
				databaseContext.Categories
				.Where(current => current.Id <= 6)
				.OrderBy(current => current.Id)
				.ToListAsync();

			//foreach (var item in categories)
			//{
			//	databaseContext.Remove(entity: item);

			//	var affectedRows =
			//		await databaseContext.SaveChangesAsync();
			//}
			databaseContext.RemoveRange(entities: categories);

			var affectedRows =
				await databaseContext.SaveChangesAsync();
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
