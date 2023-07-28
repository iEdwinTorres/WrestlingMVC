using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WrestlingMVC.Models.Championship;

public class ChampionshipCreate : IValidatableObject
{
	[Required]
	public int PromotionId { get; set; }

	[Required]
	[StringLength(100)]
	public string? Name { get; set; }

	[StringLength(500)]
	public string? Image { get; set; }

	[Required]
	public bool Status { get; set; }

	[RequiredIf("Status", true, ErrorMessage = "This field is required when the Championship is active.")]
	public DateTime? Retired { get; set; }

	[Required]
	public DateTime? Established { get; set; }

	// Add a property to hold the list of promotions
	public IEnumerable<SelectListItem> Promotions { get; set; } = new List<SelectListItem>();

	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	{
		// Custom validation logic (if needed in the future)
		// You can leave this method empty if no additional validation is required.
		yield return ValidationResult.Success;
	}
}
