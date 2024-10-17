using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Interfaces
{
    public interface IEncryptionService
    {
        public string Encrypt(string value);

        public string Decrypt(string value);
    }
}