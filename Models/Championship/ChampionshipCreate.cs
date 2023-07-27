using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Models.Championship
{
	public class ChampionshipCreate : IValidatableObject
	{
		[Required]
		public int PromotionId { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; } = string.Empty;

		public string Image { get; set; } = string.Empty;

		public bool Status { get; set; } // No default value set

		[RequiredIf("Status", true, ErrorMessage = "The Retired field is required when the Championship is active.")]
		public DateTime? Retired { get; set; }

		[Required]
		public DateTime Established { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			// Custom validation logic (if needed in the future)
			// You can leave this method empty if no additional validation is required.
			yield return ValidationResult.Success;
		}
	}
}
