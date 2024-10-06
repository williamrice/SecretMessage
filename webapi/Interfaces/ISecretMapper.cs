using webapi.Dto;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface ISecretMapper
    {
        public SecretDTO Map(Secret secret);
    }
}