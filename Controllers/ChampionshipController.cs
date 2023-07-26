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
}