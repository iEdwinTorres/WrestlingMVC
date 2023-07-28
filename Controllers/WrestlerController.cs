using Microsoft.AspNetCore.Mvc;
using WrestlingMVC.Models.Wrestler;
using WrestlingMVC.Services.Wrestlers;

namespace WrestlingMVC.Controllers;

public class WrestlerController : Controller
{
	private IWrestlerService _wrestlerService;
	public WrestlerController(IWrestlerService wrestlerService)
	{
		_wrestlerService = wrestlerService;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		IEnumerable<WrestlerListItem> wrestlers = await _wrestlerService.GetAllWrestlersAsync();
		return View(wrestlers);
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(WrestlerCreate model)
	{
		if (!ModelState.IsValid)
			return View(model);

	await _wrestlerService.CreateWrestlerAsync(model);

	return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		WrestlerDetail? model = await _wrestlerService.GetWrestlerAsync(id);

		if (model is null)
			return NotFound();

		return View("detail", model);
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		WrestlerDetail? wrestler = await _wrestlerService.GetWrestlerAsync(id);
		if (wrestler is null)
			return NotFound();

		WrestlerEdit model = new()
		{
			Id = wrestler.Id,
			Name = wrestler.Name ?? "",
			Image = wrestler.Image ?? "",
			Established = wrestler.Established,
			Retired = wrestler.Retired,
		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, WrestlerEdit model)
	{
		if (!ModelState.IsValid)
			return View(model);

		if (await _wrestlerService.UpdateWrestlerAsync(model))
			return RedirectToAction(nameof(Details), new { id = id });

		ModelState.AddModelError("Save Error", "Could not update the wrestler. Please try again.");
		return View(model);
	}
}
