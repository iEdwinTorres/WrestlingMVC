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
}