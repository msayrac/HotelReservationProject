﻿using HotelProject.EntityLayer.Concrete;
using HotelReservationProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationProject.WebUI.Controllers
{
	[AllowAnonymous]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;

		public RoleController(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}


		[HttpGet]
		public IActionResult AddRole()
		{
			return View();
		}

		[HttpPost]

		public async Task<IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
		{
			AppRole appRole = new AppRole()
			{
				Name = addRoleViewModel.RoleName
			};

			var result = await _roleManager.CreateAsync(appRole);

			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			return View();

		}













	}
}
