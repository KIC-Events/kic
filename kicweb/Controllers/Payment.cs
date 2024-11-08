using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KiCData.Models;
using KiCData.Models.WebModels;
using KiCData.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KiCWeb.Controllers
{
    [Route("[controller]")]
    public class Payment : KICController
    {
        private readonly ILogger<Payment> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICookieService _cookieService;
        private readonly IConfigurationRoot _configurationRoot;
        private readonly KiCdbContext _context;
        private readonly IPaymentService _paymentService;

        public Payment(ILogger<Payment> logger, IHttpContextAccessor contextAccessor, ICookieService cookieService, IConfigurationRoot configurationRoot, KiCdbContext kiCdbContext, IPaymentService paymentService) : base(configurationRoot, userService: null, contextAccessor, kiCdbContext, cookieService)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
            _cookieService = cookieService;
            _configurationRoot = configurationRoot;
            _context = kiCdbContext;
            _paymentService = paymentService;
        }

        [HttpGet("Purchase")]
        public IActionResult Purchase()
        {
            return View();
        }

        [HttpGet("Merch")]
        [Route("/Merch")]
        public IActionResult MerchStore()
        {
            return Redirect("https://kic-events.square.site/shop/apparel/INJSIHWIBYY7LG4HENI4NYFL");
        }

        [HttpGet("Blasphemy")]
        [Route("/Blasphemy")]
        [Route("~/Blasphemy")]
        public IActionResult Blasphemy()
        {
            ViewBag.SalesActive = true;

            if (DateTime.Now >= new DateTime(2024, 12, 15, 10, 0, 0))
            {
                ViewBag.SalesActive = false;
            }

            int standardCnt = _paymentService.CheckInventory("Blasphemy Ticket", "Standard");
            int vipCnt = _paymentService.CheckInventory("Blasphemy Ticket", "VIP");

            ViewBag.StandardCount = standardCnt;
            ViewBag.VIPCount = vipCnt;

            RegistrationViewModel viewModel = new RegistrationViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Blasphemy(RegistrationViewModel rvmUpdated)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Missing or incorrect registration info.";
                return View(rvmUpdated);
            }



            return Redirect("Success");
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View("Error!");
        //}
    }
}