using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrestlingMVC.Data
{
	public class Championship
	{
		[Key]
		public int ChampionshipId { get; set; }

		[ForeignKey(nameof(PromotionId))]
		public int PromotionId { get; set; }
		public virtual Promotion Promotion { get; set; } = null!;

		[Required]
		[MaxLength(100)]
		public string? ChampionshipName { get; set; }

		[Required]
		[MaxLength(100)]
		public string? ChampionshipImage { get; set; }

		[Required]
		public bool ChampionshipDefunct { get; set; }

		[Required]
		public DateTime ChampionshipEstablished { get; set; }

		[Required]
		public DateTime ChampionshipRetired { get; set; }
	}
}
