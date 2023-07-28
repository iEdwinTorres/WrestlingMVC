using Microsoft.EntityFrameworkCore;
using WrestlingMVC.Data;
using WrestlingMVC.Models.Promotion;

namespace WrestlingMVC.Services.Promotions;

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
				Image = model.Image,
				Status = model.Status,
				Established = model.Established,
				Retired = model.Retired
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
				Image = promotion.Image,
				Status = promotion.Status,
				Established = promotion.Established.HasValue ? (DateTime)promotion.Established : DateTime.MinValue,
				Retired = promotion.Retired
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
				Image = promotion.Image,
				Status = promotion.Status,
				Established = promotion.Established.HasValue ? (DateTime)promotion.Established : DateTime.MinValue,
				Retired = promotion.Retired
			};
		}

		public async Task<bool> UpdatePromotionAsync(PromotionEdit model)
		{
			Promotion? entity = await _context.Promotions.FindAsync(model.Id);

			if (entity is null)
				return false;
			
			entity.Name = model.Name;
			entity.Image = model.Image;
			entity.Status = model.Status;
			entity.Established = model.Established;
			entity.Retired = model.Retired;
			return await _context.SaveChangesAsync() == 1;
		}
	}
