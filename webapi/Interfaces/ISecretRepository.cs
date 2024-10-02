


using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface ISecretRepository
    {
        public Task<List<Secret>> GetSecretsAsync();
    }
}