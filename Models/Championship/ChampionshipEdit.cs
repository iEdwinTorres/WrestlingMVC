using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WrestlingMVC.Models.Championship
{
	public class ChampionshipEdit
	{
		[Required]
		public int PromotionId { get; set; }

		[Required]
		public int Id { get; set; }

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

		// Add a property to hold the list of promotions
		public IEnumerable<SelectListItem> Promotions { get; set; } = new List<SelectListItem>();
	}
}
