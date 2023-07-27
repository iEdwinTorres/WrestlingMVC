using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Models.Promotion;

public class PromotionCreate
{
	[Required]
	[StringLength(100)]
	public string Name { get; set; } = string.Empty;

	public string Logo { get; set; } = string.Empty;

	public bool Status { get; set; } // No default value set

	[RequiredIf("Status", true, ErrorMessage = "The Shuttered field is required when the Promotion is active.")]
	public DateTime? Shuttered { get; set; }

	[Required]
	public DateTime Established { get; set; }

	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	{
		// Custom validation logic (if needed in the future)
		// You can leave this method empty if no additional validation is required.
		yield return ValidationResult.Success;
	}
}
