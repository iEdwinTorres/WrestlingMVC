using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Data
{
	public class Reign
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int Title_Id { get; set; }

		[Required]
		public int Wrestle_Id { get; set; }

		[Required]
		public DateTime DateStart { get; set; }

		[Required]
		public DateTime DateEnd { get; set; }
	}
}