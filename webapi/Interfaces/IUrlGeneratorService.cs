using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Interfaces
{
    public interface IUrlGeneratorService
    {
        string GenerateUrl(string uuid, string url);
    }
}