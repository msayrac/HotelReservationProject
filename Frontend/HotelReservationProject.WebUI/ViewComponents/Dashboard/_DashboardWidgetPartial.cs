﻿using HotelReservationProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelReservationProject.WebUI.ViewComponents.Dashboard
{
	public class _DashboardWidgetPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:33170/api/DashboardWidgets/StaffCount");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				//var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
				ViewBag.v = jsonData;
			}
			return View();
		}


	}
}
