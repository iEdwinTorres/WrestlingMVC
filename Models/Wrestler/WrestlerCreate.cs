using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Models.Wrestler;

public class WrestlerCreate : IValidatableObject
{
	[Required]
	[StringLength(100)]
	public string? Name { get; set; }

	[StringLength(500)]
	public string? Image { get; set; }

	[Required]
	public bool Status { get; set; }

	[RequiredIf("Status", true, ErrorMessage = "The Retired field is required when the Wrestler is active.")]
	public DateTime? Retired { get; set; }

	[Required]
	public DateTime? Established { get; set; }

	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	{
		// Custom validation logic (if needed in the future)
		// You can leave this method empty if no additional validation is required.
		yield return ValidationResult.Success;
	}
}
