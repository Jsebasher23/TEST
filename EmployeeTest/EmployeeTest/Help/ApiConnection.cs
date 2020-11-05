using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace EmployeeTest.Help
{
    public static class ApiConnection
    {
        public static HttpClient Initial()
        {
            return new HttpClient
            {
                BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net")
            };
        }
    }
}