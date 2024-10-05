

using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dto;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repository;

public class SecretRepository : ISecretRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ISecretMapper _mapper;
    public SecretRepository(ApplicationDbContext context, ISecretMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SecretDTO?> AddSecretAsync(SecretDTO secret)
    {
        if (secret == null)
        {
            return null;
        }

        var secretToAdd = new Secret
        {
            Title = secret.Title,
            Message = secret.Message,
        };


        var result = await _context.Secrets.AddAsync(secretToAdd);
        await _context.SaveChangesAsync();
        return _mapper.Map(result.Entity);
    }

    public async Task<SecretDTO?> GetSecretByUUID(string uuid)
    {
        var secret = await _context.Secrets.FirstOrDefaultAsync(x => x.UUID == uuid);

        if (secret == null)
        {
            return null;
        }

        // delete the secret from the DB as we only allow one time access
        _context.Secrets.Remove(secret);
        await _context.SaveChangesAsync();

        return _mapper.Map(secret);
    }


}