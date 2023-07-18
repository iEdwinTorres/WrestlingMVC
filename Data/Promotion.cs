using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Data
{
	public class Promotion
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(100)]
		public string Name { get; set; } = string.Empty;

		[Required, MaxLength(100)]
		public string Logo { get; set; } = string.Empty;

		[Required]
		public bool Defunct { get; set; }

		[Required]
		public DateTime Established { get; set; }

		[Required]
		public DateTime Shuttered { get; set; }
	}
}