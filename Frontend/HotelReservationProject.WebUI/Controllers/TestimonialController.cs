using HotelReservationProject.WebUI.Models.Staff;
using HotelReservationProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelReservationProject.WebUI.Controllers
{
	public class TestimonialController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public TestimonialController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		// Listeleme Komutları
		public async Task<IActionResult> Index()
		{
			var client =_httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("http://localhost:33170/api/Testimonial");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);

				return View(values);
			}
			return View();
		}


		public async Task<IActionResult> AddTestimonial(TestimonialViewModel testimonial)
		{

			var client =_httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("http://localhost:33170/api/Testimonial");



		}





















	}
}
