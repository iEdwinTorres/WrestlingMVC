namespace WrestlingMVC.Models.Championship;

public class ChampionshipListItem
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public bool Status { get; set; }
	public DateTime? DateStart { get; set; }
	public DateTime? DateEnd { get; set; }
}