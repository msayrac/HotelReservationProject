using HotelReservationProject.WebUI.Dtos.GuestDto;
using HotelReservationProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelReservationProject.WebUI.ViewComponents.Dashboard
{
	[AllowAnonymous]
	public class _DashboardLast4StaffList : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardLast4StaffList(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:33170/api/Staff/Last4Staff");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLast4StaffDto>>(jsonData);
				return View(values);
			}

			return View();
		}



	}
}
