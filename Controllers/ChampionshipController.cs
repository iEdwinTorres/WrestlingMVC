using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WrestlingMVC.Models.Championship;
using WrestlingMVC.Models.Promotion; // Make sure to include the Promotion namespace if not already done
using WrestlingMVC.Services.Championships;
using WrestlingMVC.Services.Promotions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrestlingMVC.Controllers
{
	public class ChampionshipController : Controller
	{
		private readonly IChampionshipService _championshipService;
		private readonly IPromotionService _promotionService;

		public ChampionshipController(IChampionshipService championshipService, IPromotionService promotionService)
		{
			_championshipService = championshipService;
			_promotionService = promotionService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<ChampionshipListItem> championships = await _championshipService.GetAllChampionshipsAsync();
			return View(championships);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var model = new ChampionshipCreate();

			// Get the list of promotions and set it to the model
			var promotions = await _promotionService.GetAllPromotionsAsync();
			model.Promotions = promotions.Select(p => new SelectListItem
			{
				Value = p.Id.ToString(),
				Text = p.Name
			});

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(ChampionshipCreate model)
		{
			if (!ModelState.IsValid)
			{
				// If the model state is invalid, reload the list of promotions
				var promotions = await _promotionService.GetAllPromotionsAsync();
				model.Promotions = promotions.Select(p => new SelectListItem
				{
					Value = p.Id.ToString(),
					Text = p.Name
				});

				return View(model);
			}

			// Ensure the Established and Retired properties have the time stamp of 00:00:00
			if (model.Established != null)
			{
				model.Established = model.Established.Value.Date;
			}

			if (model.Retired != null)
			{
				model.Retired = model.Retired.Value.Date;
			}

			// Create the Championship using the ChampionshipService
			await _championshipService.CreateChampionshipAsync(model);

			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			ChampionshipDetail? model = await _championshipService.GetChampionshipAsync(id);

			if (model is null)
				return NotFound();

			return View("details", model);
		}
	}
}
