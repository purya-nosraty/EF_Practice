namespace Models_Attributes;

public class Category : Object
{
	public Category(string name, string nationalCode) : base()
	{
		Name = name;
		NationalCode = nationalCode;
	}

	//**********
	/// <summary>
	/// Primary Key
	/// </summary>
	[System.ComponentModel.DataAnnotations.Key]
	public int Key { get; private set; }
	//**********

	//**********
	///// <summary>
	///// nvarchar(50)
	///// </summary>
	//// Use in Application and Database
	//[System.ComponentModel.DataAnnotations.MaxLength(50)]

	////Use just in Application
	//[System.ComponentModel.DataAnnotations.MinLength(3)]
	//public string? Name { get; set; }
	//**********

	//**********
	/// <summary>
	/// Best Practice for codes above:
	/// </summary>
	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 300, MinimumLength = 5)]
	public string? Description { get; set; }
	//**********

	//**********
	/// <summary>
	/// This makes "Allow null = false" 
	/// and "Allow null string = false" in database:
	/// </summary>
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]
	public string Name { get; set; }
	//**********

	//**********
	[System.ComponentModel.DataAnnotations.Range(minimum: 1, maximum: 100)]
	public int Ordering { get; set; }
	//**********

	//**********
	/// <summary>
	/// RegularExpression forces to insert data according to its pattern.
	/// </summary>
	/// In this example, it forces user to insert national code in 10 digits:
	[System.ComponentModel.DataAnnotations.RegularExpression(pattern: "^\\d{10}$")]
	[System.ComponentModel.DataAnnotations.Required]

	public string NationalCode { get; set; }

	public bool ValidateNationalCode()
	{
		bool result =
			System.Text.RegularExpressions.Regex.IsMatch
				(input: NationalCode, pattern: "^\\d{10}$");

		return result;
	}
}
//**********

//**********
/// <summary>
/// Set a name for Table and Schema (it's not Required)
/// </summary>
[System.ComponentModel.DataAnnotations.Schema.Table
	(name: "Teacher Table", Schema = "EF")]
public class TeacherTable : Object
{
	public TeacherTable(string name) : base()
	{
		Name = name;
		Id = System.Guid.NewGuid();
	}

	//**********
	/// <summary>
	/// Set a name for Column
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.Column
		(name: "Techer Id")]
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	//**********

	//**********
	/// <summary>
	/// Idendtity Attributes give a number to Field and begins from one and scale one
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	//Counter
	public int Code { get; private set; }
	//**********

	//**********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]

	[System.ComponentModel.DataAnnotations.StringLength
		(maximumLength: 20, MinimumLength = 3)]

	[System.ComponentModel.DataAnnotations.Schema.Column
		("Teacher's name")]
	public string Name { get; set; }
	//**********
}