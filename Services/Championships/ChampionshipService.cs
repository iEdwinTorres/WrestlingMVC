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

	public async Task<bool> CreateChampionshipAsync(ChampionshipCreate model)
	{
		Championship entity = new()
		{
			PromotionId = model.PromotionId,
			Name = model.Name,
			Image = model.Image,
			Status = model.Status,
			Established = model.Established,
			Retired = model.Retired
		};
		_context.Championships.Add(entity);
		return await _context.SaveChangesAsync() == 1;
	}

	public async Task<IEnumerable<ChampionshipListItem>> GetAllChampionshipsAsync()
	{
		List<ChampionshipListItem> championships = await _context.Championships
			.Select(c => new ChampionshipListItem()
			{
				Id = c.Id,
				Name = c.Name,
				Status = c.Status
			}).ToListAsync();

		return championships;
	}
}