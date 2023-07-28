using Microsoft.AspNetCore.Mvc;
using WrestlingMVC.Models.Wrestler;
using WrestlingMVC.Services.Wrestlers;

namespace WrestlingMVC.Controllers;

public class WrestlerController : Controller
{
	private IWrestlerService _service;
	public WrestlerController(IWrestlerService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		IEnumerable<WrestlerListItem> wrestlers = await _service.GetAllWrestlersAsync();
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

	await _service.CreateWrestlerAsync(model);

	return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		WrestlerDetail? model = await _service.GetWrestlerAsync(id);

		if (model is null)
			return NotFound();

		return View("detail", model);
	}
}