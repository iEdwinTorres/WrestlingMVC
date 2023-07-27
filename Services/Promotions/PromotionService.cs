using Microsoft.EntityFrameworkCore;
using WrestlingMVC.Data;
using WrestlingMVC.Models.Promotion;

namespace WrestlingMVC.Services.Promotions;

public class PromotionService : IPromotionService
{
	private WrestlingDbContext _context;
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
			.Select(p => new PromotionListItem()
			{
				Id = p.Id,
				Name = p.Name,
				Status = p.Status
			}).ToListAsync();

		return promotions;
	}
}