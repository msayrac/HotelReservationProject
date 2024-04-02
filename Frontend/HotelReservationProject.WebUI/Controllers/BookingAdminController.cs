using HotelReservationProject.WebUI.Dtos.BookingDto;
using HotelReservationProject.WebUI.Dtos.GuestDto;
using HotelReservationProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelReservationProject.WebUI.Controllers
{
	[AllowAnonymous]

	public class BookingAdminController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingAdminController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:33170/api/BookingApi");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> ApprovedBooking2(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:33170/api/BookingApi/BookingApproved?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> CancelBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:33170/api/BookingApi/BookingCancel?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> WaitBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:33170/api/BookingApi/BookingWait?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]

		public async Task<IActionResult> UpdateBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync($"http://localhost:33170/api/BookingApi/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
		{		
				var client = _httpClientFactory.CreateClient();

				var jsonData = JsonConvert.SerializeObject(updateBookingDto);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

				var responseMessage = await client.PutAsync("http://localhost:33170/api/BookingApi/UpdateBooking/", stringContent);

				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
				return View();
		}





		public async Task<IActionResult> ApprovedBooking(ApprovedBookingDto approvedBookingDto)
		{
			approvedBookingDto.Status = "Onaylandı";

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(approvedBookingDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("http://localhost:33170/api/BookingApi/bbb", stringContent);


			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}















	}
}
