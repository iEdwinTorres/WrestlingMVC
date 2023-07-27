using System;
using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Data
{
	public class Championship
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int PromotionId { get; set; }

		[Required]
		[StringLength(100)]
		public string? Name { get; set; }

		public string? Image { get; set; }

		[Required]
		public bool Status { get; set; }

		[Required]
		public DateTime Established { get; set; }

		// Nullable DateTime property
		public DateTime? Retired { get; set; }

		// Navigation property to the Promotion entity
		[Required]
		public virtual Promotion? Promotion { get; set; }
	}
}
