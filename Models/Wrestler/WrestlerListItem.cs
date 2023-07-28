namespace WrestlingMVC.Models.Wrestler;

public class WrestlerListItem
{
	public int Id { get; set; }
	
	public string? Name { get; set; }

	public bool Status { get; set; }

	public DateTime? Established { get; set; }
	
	public DateTime? Retired { get; set; }
}