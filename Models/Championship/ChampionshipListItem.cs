namespace WrestlingMVC.Models.Championship;

public class ChampionshipListItem
{
	public int Id { get; set; }

	public string? Name { get; set; }

	public bool Status { get; set; }

	public DateTime? Established { get; set; }
	
	public DateTime? Retired { get; set; }
}