using WrestlingMVC.Models.Championship;

namespace WrestlingMVC.Services.Championships;

public interface IChampionshipService
{
	Task<IEnumerable<ChampionshipListItem>> GetAllChampionshipsAsync();
}