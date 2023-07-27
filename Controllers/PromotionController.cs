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

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(PromotionCreate model)
	{
		if (!ModelState.IsValid)
			return View(model);

	await _service.CreatePromotionAsync(model);

	return RedirectToAction(nameof(Index));
	}
}