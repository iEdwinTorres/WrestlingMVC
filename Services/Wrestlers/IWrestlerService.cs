using WrestlingMVC.Models.Wrestler;

namespace WrestlingMVC.Services.Wrestlers;

public interface IWrestlerService
{
	Task<IEnumerable<WrestlerListItem>> GetAllWrestlersAsync();
	Task<bool> CreateWrestlerAsync(WrestlerCreate model);
}