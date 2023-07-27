namespace WrestlingMVC.Models.Wrestler;

public class WrestlerListItem
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public bool Status { get; set; }
	public DateTime? DateStart { get; set; }
	public DateTime? DateEnd { get; set; }
}