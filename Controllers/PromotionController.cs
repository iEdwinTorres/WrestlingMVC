using Microsoft.AspNetCore.Mvc;
using WrestlingMVC.Models.Promotion;
using WrestlingMVC.Services.Promotions;

namespace WrestlingMVC.Controllers;

public class PromotionController : Controller
{
	private IPromotionService _promotionService;
	public PromotionController(IPromotionService promotionService)
	{
		_promotionService = promotionService;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		IEnumerable<PromotionListItem> promotions = await _promotionService.GetAllPromotionsAsync();
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

		await _promotionService.CreatePromotionAsync(model);

		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		PromotionDetail? model = await _promotionService.GetPromotionAsync(id);

		if (model is null)
			return NotFound();

		return View("detail", model);
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		PromotionDetail? promotion = await _promotionService.GetPromotionAsync(id);
		if (promotion is null)
			return NotFound();

		PromotionEdit model = new()
		{
			Id = promotion.Id,
			Name = promotion.Name ?? "",
			Image = promotion.Image ?? "",
			Established = promotion.Established,
			Retired = promotion.Retired,
		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, PromotionEdit model)
	{
		if (!ModelState.IsValid)
			return View(model);

		if (await _promotionService.UpdatePromotionAsync(model))
			return RedirectToAction(nameof(Details), new { id = id });

		ModelState.AddModelError("Save Error", "Could not update the Promotion. Please try again.");
		return View(model);
	}
}