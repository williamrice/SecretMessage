using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Dto
{
    public class SecretDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public string UUID { get; set; } = string.Empty;

    }
}