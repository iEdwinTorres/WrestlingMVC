using System;
using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Data
{
	public class Wrestler
	{
		[Key]
		public int WrestlerId { get; set; }

		[Required]
		[MaxLength(100)]
		public string? WrestlerName { get; set; }

		[MaxLength(100)]
		public string? WrestlerPicture { get; set; }

		[Required]
		public bool WrestlerRetired { get; set; }

		public DateTime? WrestlerDateStart { get; set; }

		public DateTime? WrestlerDateEnd { get; set; }
	}
}
