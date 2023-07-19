using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrestlingMVC.Data
{
	public class Reign
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(ChampionshipId))]
		public virtual Championship ChampionshipId { get; set; }

		[ForeignKey(nameof(WrestlerId))]
		public virtual Wrestler WrestlerId { get; set; }

		[Required]
		public DateTime ReignDateStart { get; set; }

		public DateTime? ReignDateEnd { get; set; }
	}
}
