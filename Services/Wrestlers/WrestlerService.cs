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

	public async Task<bool> CreateWrestlerAsync(WrestlerCreate model)
	{
		Wrestler entity = new()
		{
			Name = model.Name,
			Picture = model.Picture,
			Status = model.Status,
			DateStart = model.DateStart,
			DateEnd = model.DateEnd
		};
		_context.Wrestlers.Add(entity);
		return await _context.SaveChangesAsync() == 1;
	}

	public async Task<IEnumerable<WrestlerListItem>> GetAllWrestlersAsync()
	{
		List<WrestlerListItem> wrestlers = await _context.Wrestlers
			.Select(w => new WrestlerListItem()
			{
				Id = w.Id,
				Name = w.Name,
				Status = w.Status,
				DateStart = w.DateStart,
				DateEnd = w.DateEnd
			}).ToListAsync();

		return wrestlers;
	}
}
