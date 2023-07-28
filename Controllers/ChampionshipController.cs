using Microsoft.AspNetCore.Mvc;
using WrestlingMVC.Models.Championship;
using WrestlingMVC.Services.Championships;

namespace WrestlingMVC.Controllers;

public class ChampionshipController : Controller
{
	private IChampionshipService _service;
	public ChampionshipController(IChampionshipService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		IEnumerable<ChampionshipListItem> championships = await _service.GetAllChampionshipsAsync();
		return View(championships);
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(ChampionshipCreate model)
	{
		if (!ModelState.IsValid)
			return View(model);

	await _service.CreateChampionshipAsync(model);

	return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		ChampionshipDetail? model = await _service.GetChampionshipAsync(id);

		if (model is null)
			return NotFound();

		return View("detail", model);
	}
}