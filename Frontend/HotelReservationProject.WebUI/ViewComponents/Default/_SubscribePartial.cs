using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.ViewComponents.Default
{
	public class _SubscribePartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
