using Microsoft.EntityFrameworkCore;
using WrestlingMVC.Data;
using WrestlingMVC.Models.Championship;

namespace WrestlingMVC.Services.Championships;

public class ChampionshipService : IChampionshipService
{
	private WrestlingDbContext _context;
	public ChampionshipService(WrestlingDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<ChampionshipListItem>> GetAllChampionshipsAsync()
	{
		List<ChampionshipListItem> championships = await _context.Championships
			.Select(c => new ChampionshipListItem()
			{
				ChampionshipId = c.Id,
				ChampionshipName = c.Name,
				ChampionshipDefunct = c.Defunct
			}).ToListAsync();

		return championships;
	}
}