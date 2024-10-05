using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Dto;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface ISecretMapper
    {
        public SecretDTO Map(Secret secret);
    }
}