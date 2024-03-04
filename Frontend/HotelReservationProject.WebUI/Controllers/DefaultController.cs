using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
