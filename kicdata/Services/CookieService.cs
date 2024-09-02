﻿using System.Net;
using Microsoft.AspNetCore.Http;

namespace KiCData.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CookieService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Using an HttpRequest, checks if the provided request contains a cookie that indicates the user has passed the age gate.
        /// </summary>
        /// <param name="context">The default HttpContext for the current action.</param>
        /// <returns>bool</returns>
        public bool AgeGateCookieAccepted(HttpRequest context)
        {
            var cookie = context.Cookies["age_Gate"];
            
            if (cookie == null) { return false; }
            else if (cookie == "true") { return true; }
            else { return false; }
        }

        public bool AuthTokenCookie(HttpRequest context)
        {
            var cookie = context.Cookies["kic_auth"];

            if (cookie == null) { return false; }
            else if (cookie == "true") { return true; }
            else { return false; }
        }

        /// <summary>
        /// Builds a CookieOptions configured to store the user's acceptance of the age gate disclaimer.
        /// </summary>
        /// <returns>CookieOptions</returns>
        public CookieOptions NewCookieFactory()
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Path = "/";
            cookie.Secure = true;
            cookie.Expires = DateTime.Now.AddDays(1);

            return cookie;
        }

        public void DeleteCookie(HttpRequest context, string key)
        {
            if (context.Cookies.ContainsKey(key))
            {
                context.HttpContext.Response.Cookies.Delete(key);
            }
        }
    }
}
