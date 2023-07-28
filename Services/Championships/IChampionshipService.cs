using WrestlingMVC.Models.Championship;

namespace WrestlingMVC.Services.Championships;

public interface IChampionshipService
{
	Task<IEnumerable<ChampionshipListItem>> GetAllChampionshipsAsync();
	Task<bool> CreateChampionshipAsync(ChampionshipCreate model);
	Task<ChampionshipDetail?> GetChampionshipAsync(int id);
	Task<bool> UpdateChampionshipAsync(ChampionshipEdit model);
}
