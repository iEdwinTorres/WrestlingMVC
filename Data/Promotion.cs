using System;
using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Data
{
	public class Promotion
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string? Name { get; set; }

		[Required]
		[MaxLength(100)]
		public string? Logo { get; set; }

		[Required]
		public bool Status { get; set; }

		[Required]
		public DateTime Established { get; set; }

		[Required]
		public DateTime Shuttered { get; set; }
	}
}
