using webapi.Dto;

namespace webapi.Interfaces
{
    public interface ISecretRepository
    {
        public Task<SecretDTO?> GetSecretByUUID(string uuid);
        public Task<SecretDTO?> AddSecretAsync(SecretDTO secret);
    }
}