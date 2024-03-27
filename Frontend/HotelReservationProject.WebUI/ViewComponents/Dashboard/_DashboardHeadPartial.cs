using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.ViewComponents.Dashboard
{
	public class _DashboardHeadPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}


	}
}
