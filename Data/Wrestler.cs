using System;
using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Data
{
	public class Wrestler
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string? Name { get; set; }

		[MaxLength(100)]
		public string? Picture { get; set; }

		[Required]
		public bool Retired { get; set; }

		public DateTime? DateStart { get; set; }

		public DateTime? DateEnd { get; set; }
	}
}
