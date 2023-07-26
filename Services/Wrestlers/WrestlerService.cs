using Microsoft.EntityFrameworkCore;
using WrestlingMVC.Data;
using WrestlingMVC.Models.Wrestler;

namespace WrestlingMVC.Services.Wrestlers;

public class WrestlerService : IWrestlerService
{
	private WrestlingDbContext _context;
	public WrestlerService(WrestlingDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<WrestlerListItem>> GetAllWrestlersAsync()
	{
		List<WrestlerListItem> wrestlers = await _context.Wrestlers
			.Select(w => new WrestlerListItem()
			{
				WrestlerId = w.Id,
				WrestlerName = w.Name,
				WrestlerRetired = w.Retired
			}).ToListAsync();

		return wrestlers;
	}
}
