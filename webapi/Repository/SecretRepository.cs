

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

    public async Task<Secret?> GetSecretByUUIDAsync(string uuid)
    {
        var secret = await _context.Secrets.FirstOrDefaultAsync(x => x.UUID == uuid);

        return secret;
    }


}