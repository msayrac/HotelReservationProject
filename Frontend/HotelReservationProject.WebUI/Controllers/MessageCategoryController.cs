using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.Controllers
{
	public class MessageCategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
