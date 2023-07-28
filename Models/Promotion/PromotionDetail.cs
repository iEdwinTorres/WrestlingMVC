namespace WrestlingMVC.Models.Promotion;

public class PromotionDetail
{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Image { get; set; }

		public bool Status { get; set; }

		public DateTime Established { get; set; }

		// Nullable DateTime property
		public DateTime? Retired { get; set; }

}