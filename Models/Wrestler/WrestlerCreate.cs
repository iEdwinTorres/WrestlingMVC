using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Models.Wrestler;

public class WrestlerCreate
{
	[Required]
	[StringLength(100)]
	public string Name { get; set; } = string.Empty;

	public string Picture { get; set; } = string.Empty;

	public bool Status { get; set; } // No default value set

	[RequiredIf("Status", true, ErrorMessage = "The Date End field is required when the Wrestler is active.")]
	public DateTime? DateEnd { get; set; }

	[Required]
	public DateTime DateStart { get; set; }

	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	{
		// Custom validation logic (if needed in the future)
		// You can leave this method empty if no additional validation is required.
		yield return ValidationResult.Success;
	}
}
