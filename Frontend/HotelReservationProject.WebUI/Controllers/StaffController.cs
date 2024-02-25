using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.Controllers
{
	public class StaffController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
