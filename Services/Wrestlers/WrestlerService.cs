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
			Image = model.Image,
			Status = model.Status,
			Established = model.Established,
			Retired = model.Retired
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
				Established = w.Established,
				Retired = w.Retired
			}).ToListAsync();

		return wrestlers;
	}

	public async Task<WrestlerDetail?> GetWrestlerAsync(int id)
	{
		Wrestler? wrestler = await _context.Wrestlers
			 .FirstOrDefaultAsync(w => w.Id == id);

		if (wrestler is null)
		{
			return null; // Return null if no wrestler is found with the specified ID
		}

		// If wrestler is not null, create and return the WrestlerDetail object
		return new WrestlerDetail
		{
			Id = wrestler.Id,
			Name = wrestler.Name,
			Image = wrestler.Image,
			Status = wrestler.Status,
			Established = wrestler.Established.HasValue ? (DateTime)wrestler.Established : DateTime.MinValue,
			Retired = wrestler.Retired
		};
	}

	public async Task<WrestlerDetail?> GetWrestlerDetailAsync(int id)
	{
		Wrestler? wrestler = await _context.Wrestlers
			.FirstOrDefaultAsync(w => w.Id == id);

		return wrestler is null ? null : new()
		{
			Id = wrestler.Id,
			Name = wrestler.Name,
			Image = wrestler.Image,
			Status = wrestler.Status,
			Established = wrestler.Established.HasValue ? (DateTime)wrestler.Established : DateTime.MinValue,
			Retired = wrestler.Retired
		};
	}
}
