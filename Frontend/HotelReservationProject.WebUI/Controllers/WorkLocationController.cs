﻿using HotelReservationProject.WebUI.Dtos.WorkLocationDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelReservationProject.WebUI.Controllers
{
	[AllowAnonymous]
	public class WorkLocationController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public WorkLocationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:33170/api/WorkLocation");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(jsonData);
				return View(values);
			}

			return View();
		}


		[HttpGet]
		public IActionResult AddWorkLocation()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddWorkLocation(CreateWorkLocationDto createWorkLocationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createWorkLocationDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");


			var responseMessage = await client.PostAsync("http://localhost:33170/api/WorkLocation", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		public async Task<IActionResult> DeleteWorkLocation(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:33170/api/WorkLocation/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> UpdateWorkLocation(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync($"http://localhost:33170/api/WorkLocation/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateWorkLocationDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateRoom(UpdateWorkLocationDto updateWorkLocationDto)
		{
			var client = _httpClientFactory.CreateClient();

			var jsonData = JsonConvert.SerializeObject(updateWorkLocationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("http://localhost:33170/api/WorkLocation", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


	}
}
