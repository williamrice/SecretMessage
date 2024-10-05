


using Microsoft.AspNetCore.Mvc;
using webapi.Dto;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface ISecretRepository
    {
        public Task<SecretDTO?> GetSecretByUUID(string uuid);
        public Task<SecretDTO?> AddSecretAsync(SecretDTO secret);
    }
}