namespace Persistence;

public class Category : object
{
	#region Constructor
	public Category() : base()
	{
	}
	#endregion /Constructor

	#region Properties
	//**********
	public int Id { get; set; }
	//**********

	//**********
	public string? Name { get; set; }
	//**********
	#endregion /Properties
}
