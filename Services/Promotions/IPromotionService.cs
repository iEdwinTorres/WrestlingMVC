using WrestlingMVC.Models.Promotion;

namespace WrestlingMVC.Services.Promotions;

public interface IPromotionService
{
	Task<IEnumerable<PromotionListItem>> GetAllPromotionsAsync();
	Task<bool> CreatePromotionAsync(PromotionCreate model);
	Task<PromotionDetail?> GetPromotionAsync(int id);
	Task<bool> UpdatePromotionAsync(PromotionEdit model);

}