using webapi.Dto;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Mappers
{
    public class SecretMapper : ISecretMapper
    {
        public SecretDTO Map(Secret secret)
        {
            return new SecretDTO
            {
                Title = secret.Title,
                Message = secret.Message,
                UUID = secret.UUID
            };
        }
    }
}