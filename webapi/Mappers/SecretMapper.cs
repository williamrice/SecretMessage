using webapi.Dto;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Mappers
{
    public class SecretMapper : ISecretMapper
    {
        public CreateSecretDTO createMap(Secret secret)
        {
            return new CreateSecretDTO
            {
                Title = secret.Title,
                Message = secret.Message
            };
        }

        public SecretDTO Map(Secret secret)
        {
            return new SecretDTO
            {
                UUID = secret.UUID
            };
        }
    }
}