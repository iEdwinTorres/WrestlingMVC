using System;
using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Data
{
	public class Promotion
	{
		[Key]
		public int PromotionId { get; set; }

		[Required]
		[MaxLength(100)]
		public string? PromotionName { get; set; }

		[Required]
		[MaxLength(100)]
		public string? PromotionLogo { get; set; }

		[Required]
		public bool PromotionDefunct { get; set; }

		[Required]
		public DateTime PromotionEstablished { get; set; }

		[Required]
		public DateTime PromotionShuttered { get; set; }
	}
}
