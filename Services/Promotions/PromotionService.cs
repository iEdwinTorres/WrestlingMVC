using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrestlingMVC.Data;
using WrestlingMVC.Models.Promotion;

namespace WrestlingMVC.Services.Promotions
{
	public class PromotionService : IPromotionService
	{
		private readonly WrestlingDbContext _context;

		public PromotionService(WrestlingDbContext context)
		{
			_context = context;
		}

		public async Task<bool> CreatePromotionAsync(PromotionCreate model)
		{
			Promotion entity = new()
			{
				Name = model.Name,
				Logo = model.Logo,
				Status = model.Status,
				Established = model.Established,
				Shuttered = model.Shuttered
			};
			_context.Promotions.Add(entity);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<IEnumerable<PromotionListItem>> GetAllPromotionsAsync()
		{
			List<PromotionListItem> promotions = await _context.Promotions
				 .Select(p => new PromotionListItem
				 {
					 Id = p.Id,
					 Name = p.Name,
					 Status = p.Status
				 }).ToListAsync();

			return promotions;
		}

		public async Task<PromotionDetail?> GetPromotionAsync(int id)
		{
			Promotion? promotion = await _context.Promotions
				 .FirstOrDefaultAsync(p => p.Id == id);

			if (promotion is null)
			{
				return null; // Return null if no promotion is found with the specified ID
			}

			// If promotion is not null, create and return the PromotionDetail object
			return new PromotionDetail
			{
				Id = promotion.Id,
				Name = promotion.Name,
				Logo = promotion.Logo,
				Status = promotion.Status,
				Established = promotion.Established,
				Shuttered = promotion.Shuttered
			};
		}

		public async Task<PromotionDetail?> GetPromotionDetailAsync(int id)
		{
			Promotion? promotion = await _context.Promotions
				 .FirstOrDefaultAsync(p => p.Id == id);

			if (promotion is null)
			{
				return null; // Return null if no promotion is found with the specified ID
			}

			// If promotion is not null, create and return the PromotionDetail object
			return new PromotionDetail
			{
				Id = promotion.Id,
				Name = promotion.Name,
				Logo = promotion.Logo,
				Status = promotion.Status,
				Established = promotion.Established,
				Shuttered = promotion.Shuttered
			};
		}
	}
}
