using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.ViewComponents.Default
{
	public class _OurRoomsPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
