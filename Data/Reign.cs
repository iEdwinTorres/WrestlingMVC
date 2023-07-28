using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrestlingMVC.Data
{
	public class Reign
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(Championship))]
		public int? ChampionshipId { get; set; }
		public virtual Championship? Championship { get; set; }

		[ForeignKey(nameof(Wrestler))]
		public int? WrestlerId { get; set; }
		public virtual Wrestler? Wrestler { get; set; }

		[Required]
		public DateTime ReignDateStart { get; set; }

		public DateTime? ReignDateEnd { get; set; }
	}
}
