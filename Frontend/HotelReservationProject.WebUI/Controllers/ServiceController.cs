﻿using HotelReservationProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace HotelReservationProject.WebUI.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ServiceController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:33170/api/Service");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
				return View(values);
			}
			return View();
		}


		[HttpGet]
		public IActionResult AddService()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createServiceDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("http://localhost:33170/api/Service", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();



		}





	}
}
