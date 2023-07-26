using Microsoft.AspNetCore.Mvc;
using WrestlingMVC.Models.Promotion;
using WrestlingMVC.Services.Promotions;

namespace WrestlingMVC.Controllers;

public class PromotionController : Controller
{
	private IPromotionService _service;
	public PromotionController(IPromotionService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		IEnumerable<PromotionListItem> promotions = await _service.GetAllPromotionsAsync();
		return View(promotions);
	}
}