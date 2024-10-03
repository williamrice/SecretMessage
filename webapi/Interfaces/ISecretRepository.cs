


using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface ISecretRepository
    {
        public Task<Secret?> GetSecretByUUIDAsync(string uuid);
    }
}