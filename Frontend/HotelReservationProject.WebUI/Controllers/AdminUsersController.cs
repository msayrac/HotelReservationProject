﻿using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.Controllers
{
	[AllowAnonymous]
	public class AdminUsersController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public AdminUsersController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var values = _userManager.Users.ToList();

			return View(values);
		}
	}
}
