﻿using HotelReservationProject.WebUI.Dtos.BookingDto;
using HotelReservationProject.WebUI.Dtos.ContactDto;
using HotelReservationProject.WebUI.Dtos.MessageCategoryDto;
using HotelReservationProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelReservationProject.WebUI.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:33170/api/MessageCategory");

			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);

			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.MessageCategoryName,
												Value = x.MessageCategoryID.ToString()
											}).ToList();
			ViewBag.v = values2;

			return View();
		}

		[HttpGet]
		public PartialViewResult SendMessage()
		{
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
		{
			createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createContactDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			await client.PostAsync("http://localhost:33170/api/Contact", stringContent);

			return RedirectToAction("Index", "Default");
		}

















	}
}
