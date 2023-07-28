namespace WrestlingMVC.Models.Promotion;

public class PromotionDetail
{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Logo { get; set; }

		public bool Status { get; set; }

		public DateTime Established { get; set; }

		// Nullable DateTime property
		public DateTime? Shuttered { get; set; }

}