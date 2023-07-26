using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrestlingMVC.Data
{
	public class Championship
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(PromotionId))]
		public int PromotionId { get; set; }
		public virtual Promotion Promotion { get; set; } = null!;

		[Required]
		[MaxLength(100)]
		public string? Name { get; set; }

		[Required]
		[MaxLength(100)]
		public string? Image { get; set; }

		[Required]
		public bool Defunct { get; set; }

		[Required]
		public DateTime Established { get; set; }
		
		public DateTime Retired { get; set; }
	}
}
