using WrestlingMVC.Models.Promotion;

namespace WrestlingMVC.Services.Promotions;

public interface IPromotionService
{
	Task<IEnumerable<PromotionListItem>> GetAllPromotionsAsync();
}