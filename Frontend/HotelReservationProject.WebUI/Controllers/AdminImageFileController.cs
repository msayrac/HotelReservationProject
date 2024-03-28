﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelReservationProject.WebUI.Controllers
{
	[AllowAnonymous]

	public class AdminImageFileController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(IFormFile file)
		{
			var stream = new MemoryStream();
			await file.CopyToAsync(stream);
			var bytes = stream.ToArray();

			ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);

			byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

			multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

			var httpClient = new HttpClient();

			await httpClient.PostAsync("http://localhost:33170/api/FileImage", multipartFormDataContent);

			return View();
		}
	}
}
