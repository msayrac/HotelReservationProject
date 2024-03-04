using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.ViewComponents.Default
{
	public class _SpinnerPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
