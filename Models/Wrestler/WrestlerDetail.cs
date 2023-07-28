namespace WrestlingMVC.Models.Wrestler;

public class WrestlerDetail
{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Picture { get; set; }

		public bool Status { get; set; }

		public DateTime DateStart { get; set; }

		// Nullable DateTime property
		public DateTime? DateEnd { get; set; }

}