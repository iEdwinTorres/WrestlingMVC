using Microsoft.EntityFrameworkCore;
using WrestlingMVC.Data;
using WrestlingMVC.Models.Championship;
using System;

namespace WrestlingMVC.Services.Championships
{
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

		public async Task<ChampionshipDetail?> GetChampionshipAsync(int id)
		{
			Championship? championship = await _context.Championships
				 .FirstOrDefaultAsync(c => c.Id == id);

			if (championship is null)
			{
				return null; // Return null if no championship is found with the specified ID
			}

			// If championship is not null, create and return the ChampionshipDetail object
			return new ChampionshipDetail
			{
				Id = championship.Id,
				Name = championship.Name,
				Image = championship.Image,
				Status = championship.Status,
				Established = championship.Established.HasValue ? (DateTime)championship.Established : DateTime.MinValue,
				Retired = championship.Retired
			};
		}

		public async Task<ChampionshipDetail?> GetChampionshipDetailAsync(int id)
		{
			Championship? championship = await _context.Championships
				  .FirstOrDefaultAsync(c => c.Id == id);

			return championship is null ? null : new ChampionshipDetail
			{
				Id = championship.Id,
				PromotionId = championship.PromotionId,
				Name = championship.Name,
				Image = championship.Image,
				Status = championship.Status,
				Established = championship.Established.HasValue ? (DateTime)championship.Established : DateTime.MinValue,
				Retired = championship.Retired
			};
		}
	}
}
