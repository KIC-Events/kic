using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KiCData.Services;
using KiCData.Models;
using KiCData.Models.WebModels;
using KiCData.Models.WebModels.Member;

namespace KiCWeb.Controllers
{
	[Route("[controller]")]
	public class Member : Controller
	{
		private readonly ILogger<Member> _logger;
		private readonly ICookieService _cookieService;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IUserService _userService;

		public Member(ILogger<Member> logger, IUserService userService, ICookieService cookieService, IHttpContextAccessor contextAccessor)
		{
			_logger = logger;
			_userService = userService;
			_cookieService = cookieService;
			_contextAccessor = contextAccessor;
		}

		[HttpGet]
		public IActionResult Register()
		{
            if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
            {
                return Redirect("Home/Index");
            }

            RegisterViewModel rvm = new RegisterViewModel()
			{
				LegalName = "",
				EmailAddress = "",
				FetName = "",
				UserName = "",
				Password = "",
				Password2 = ""
			};
		
			return View(rvm);
		}
		
		[HttpPost]
		public IActionResult Register(RegisterViewModel rvmUpdated)
		{
			if (rvmUpdated.Password != rvmUpdated.Password2)
			{
				ViewBag.ErrorMessage = "Passwords do not match.";
				rvmUpdated.Password = "";
				rvmUpdated.Password2 = "";
				return View(rvmUpdated);
			}
		
			WebUser newUser = _userService.CreateUser(rvmUpdated);
		
			return View("~/Views/Member/RegisterSuccess.cshtml", newUser);
		}

		[HttpGet]
		public IActionResult Login()
		{
            if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
            {
                return Redirect("Home/Index");
            }

			return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View("Error!");
		}
	}
}