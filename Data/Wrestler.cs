using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Data
{
	public class Wrestler
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(100)]
		public string Name { get; set; } = string.Empty;

		[Required, MaxLength(100)]
		public string Picture { get; set; } = string.Empty;

		[Required]
		public bool Retired { get; set; }

		[Required]
		public DateTime DateStart { get; set; }

		[Required]
		public DateTime DateEnd { get; set; }
	}
}