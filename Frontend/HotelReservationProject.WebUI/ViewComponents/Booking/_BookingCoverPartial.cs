using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.ViewComponents.Booking
{
	public class _BookingCoverPartial:ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			return View();
		} 
	}
}
