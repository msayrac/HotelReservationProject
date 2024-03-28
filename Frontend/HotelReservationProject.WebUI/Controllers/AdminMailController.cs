﻿using HotelReservationProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelReservationProject.WebUI.Controllers
{
	[AllowAnonymous]

	public class AdminMailController : Controller
	{

		[HttpGet]
		public IActionResult Index()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Index(AdminMailViewModel model)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "msayracode@gmail.com");

			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);

			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();

			bodyBuilder.TextBody = model.Body;

			mimeMessage.Body =bodyBuilder.ToMessageBody();

			mimeMessage.Subject =model.Subject;

			SmtpClient client = new SmtpClient();

			client.Connect("smtp.gmail.com",587,false);

			client.Authenticate("msayracode@gmail.com", "qzvnirciogvrkklv");

			client.Send(mimeMessage);

			client.Disconnect(true);

			//Gönderilen Mailin veri tabanına kaydedilmesi

			return View();
		}
	}
}
