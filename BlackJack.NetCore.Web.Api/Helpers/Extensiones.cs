using Microsoft.AspNetCore.Http;
using System;

namespace BlackJack.NetCore.Web.Api.Helpers
{
    public static class Extensiones
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalcularEdad(this DateTime fechaNacimiento)
        {
            var age = DateTime.Today.Year - fechaNacimiento.Year;
            if (fechaNacimiento.AddYears(age) > DateTime.Today)
                age--;
            return age;
        }
    }
}
