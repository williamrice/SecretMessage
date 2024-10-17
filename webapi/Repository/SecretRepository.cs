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

    private readonly IEncryptionService _encryptionService;
    public SecretRepository(ApplicationDbContext context, ISecretMapper mapper, IEncryptionService encryptionService)
    {
        _context = context;
        _mapper = mapper;

        _encryptionService = encryptionService;
    }

    public async Task<SecretDTO?> AddSecretAsync(CreateSecretDTO secret)
    {
        if (secret == null)
        {
            return null;
        }

        var encryptedTitle = _encryptionService.Encrypt(secret.Title);
        var encryptedMessage = _encryptionService.Encrypt(secret.Message);

        var secretToAdd = new Secret
        {
            Title = encryptedTitle,
            Message = encryptedMessage,
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

        secret.Title = _encryptionService.Decrypt(secret.Title);
        secret.Message = _encryptionService.Decrypt(secret.Message);

        return _mapper.Map(secret);
    }


}