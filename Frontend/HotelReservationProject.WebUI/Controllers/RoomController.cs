using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.Controllers
{

	public class RoomController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
