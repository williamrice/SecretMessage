

using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repository;

public class SecretRepository : ISecretRepository
{
    private readonly ApplicationDbContext _context;
    public SecretRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Secret>> GetSecretsAsync()
    {
        return await _context.Secrets.ToListAsync();
    }
}