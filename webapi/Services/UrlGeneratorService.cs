using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Interfaces;
using webapi.Services;

namespace webapi.Services
{
    public class UrlGeneratorService : IUrlGeneratorService
    {
        public string GenerateUrl(string uuid, string url)
        {
            return $"{url}/secret-message/{uuid}";
        }
    }
}