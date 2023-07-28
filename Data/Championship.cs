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

		[StringLength(500)]
		public string? Image { get; set; }

		[Required]
		public bool Status { get; set; }

		[Required]
		[Display(Name = "Established")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? Established { get; set; }

		[Display(Name = "Retired")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? Retired { get; set; }

		// Navigation property to the Promotion entity
		[Required]
		public virtual Promotion? Promotion { get; set; }
	}
}
