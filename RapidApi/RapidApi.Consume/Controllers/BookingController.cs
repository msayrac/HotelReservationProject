﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models;
using System.Net.Http.Headers;

namespace RapidApi.Consume.Controllers
{
	public class BookingController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?room_number=1&adults_number=2&checkout_date=2024-03-27&filter_by_currency=EUR&units=metric&locale=en-gb&checkin_date=2024-03-24&dest_type=city&dest_id=-1456928&order_by=popularity&children_ages=5%2C0&children_number=2&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0"),
				Headers =
	{
		{ "X-RapidAPI-Key", "fca0ab1c87msh2c00b12fe3e5e15p1ef69fjsn35e5b3dae135" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);

				return View(values.results.ToList());
			}
		}
	}
}
