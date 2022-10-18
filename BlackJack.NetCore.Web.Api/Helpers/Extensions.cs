﻿using Microsoft.AspNetCore.Http;
using System;

namespace BlackJack.NetCore.Web.Api.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime DateOfBirth)
        {
            var age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.AddYears(age) > DateTime.Today)
                age--;
            return age;
        }
    }
}
