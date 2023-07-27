using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Models.Wrestler;
	public class WrestlerCreate
	{
		[Required]
		[StringLength(100)]
		public string Name { get; set; } = string.Empty;

		public string Picture { get; set; } = string.Empty;

		[Required]
		public bool Status { get; set; }

		[RequiredIf("Status", true)]
		public DateTime? DateEnd { get; set; }

		[Required]
		public DateTime DateStart { get; set; }
	}
