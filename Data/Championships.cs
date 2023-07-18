using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrestlingMVC.Data
{
	public class Championships
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Promotion")]
		public int Promotion { get; set; }

		[Required, MaxLength(100)]
		public string Name { get; set; } = string.Empty;

		[Required, MaxLength(100)]
		public string Image { get; set; } = string.Empty;

		[Required]
		public bool Defunct { get; set; }

		[Required]
		public DateTime Established { get; set; }

		[Required]
		public DateTime Retired { get; set; }
	}
}