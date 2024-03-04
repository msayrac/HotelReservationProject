using Microsoft.AspNetCore.Mvc;
namespace HotelReservationProject.WebUI.ViewComponents.Default
{
	public class _TrailerPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
