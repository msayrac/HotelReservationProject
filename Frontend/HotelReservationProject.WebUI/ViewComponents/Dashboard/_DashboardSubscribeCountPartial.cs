﻿using HotelReservationProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace HotelReservationProject.WebUI.ViewComponents.Dashboard
{
	public class _DashboardSubscribeCountPartial : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/tarkan"),
				Headers =
	{
		{ "X-RapidAPI-Key", "fca0ab1c87msh2c00b12fe3e5e15p1ef69fjsn35e5b3dae135" },
		{ "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);

				ViewBag.v1 = resultInstagramFollowersDtos.followers;
				ViewBag.v2 = resultInstagramFollowersDtos.following;
			}

			var client2 = new HttpClient();
			var request2 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=nike"),
				Headers =
	{
		{ "X-RapidAPI-Key", "fca0ab1c87msh2c00b12fe3e5e15p1ef69fjsn35e5b3dae135" },
		{ "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
	},
			};
			using (var response2 = await client2.SendAsync(request2))
			{
				response2.EnsureSuccessStatusCode();
				var body2 = await response2.Content.ReadAsStringAsync();

				ResultTwitterFollowersDto resultTwitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);

				ViewBag.v3 = resultTwitterFollowersDto.data.user_info.followers_count;
				ViewBag.v4 = resultTwitterFollowersDto.data.user_info.friends_count;
			}


			var client3 = new HttpClient();
			var request3 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fmuhammedsayrac%2F&include_skills=false"),
				Headers =
	{
		{ "X-RapidAPI-Key", "fca0ab1c87msh2c00b12fe3e5e15p1ef69fjsn35e5b3dae135" },
		{ "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
	},
			};
			using (var response3 = await client3.SendAsync(request3))
			{
				response3.EnsureSuccessStatusCode();
				var body3 = await response3.Content.ReadAsStringAsync();

				ResultLinkedinFollowersDto resultLinkedinFollowersDto = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body3);

				ViewBag.V5 = resultLinkedinFollowersDto.data.followers_count;
			}

			return View();



		}
	}
}
