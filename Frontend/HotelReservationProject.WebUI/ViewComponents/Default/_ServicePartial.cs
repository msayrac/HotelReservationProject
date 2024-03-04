using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.ViewComponents.Default
{
	public class _ServicePartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
