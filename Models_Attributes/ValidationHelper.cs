using System.ComponentModel.DataAnnotations;

namespace Models_Attributes;

public static class ValidationHelper : Object
{
	static ValidationHelper()
	{
	}

	public static bool IsValid(object entity)
	{
		var validationContext =
			new System.ComponentModel.DataAnnotations.ValidationContext(instance: entity);

		var validationResult =
			new System.Collections.Generic
			.List<System.ComponentModel.DataAnnotations.ValidationResult>();

		var isValid =
			System.ComponentModel.DataAnnotations.Validator
			.TryValidateObject(instance: entity, validationContext: validationContext,
			validationResults: validationResult, validateAllProperties: true);

		return isValid;
	}

}
