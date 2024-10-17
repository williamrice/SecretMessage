using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using webapi.Interfaces;

namespace webapi.Services
{
    public class EncryptionService : IEncryptionService
    {

        private readonly IConfiguration _configuration;
        private readonly string? _password;
        public EncryptionService(IConfiguration configuration)
        {

            _configuration = configuration;
            _password = _configuration["EncryptionSecret"];
        }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(_password))
                throw new ArgumentNullException(nameof(_password), "EncryptionSecret not found");

            byte[] saltKey = new byte[16];
            byte[] saltIV = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltKey);
                rng.GetBytes(saltIV);
            }

            Rfc2898DeriveBytes keyBytes = new(_password, saltKey, 1000, HashAlgorithmName.SHA256);
            Rfc2898DeriveBytes ivBytes = new(_password, saltIV, 1000, HashAlgorithmName.SHA256);

            using Aes aes = Aes.Create();
            aes.Key = keyBytes.GetBytes(32);
            aes.IV = ivBytes.GetBytes(16);
            aes.Padding = PaddingMode.PKCS7;

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // Encrypt the data
            using MemoryStream ms = new();
            using (CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
                cs.FlushFinalBlock();
            }

            byte[] encryptedBytes = ms.ToArray();
            byte[] result = new byte[saltKey.Length + saltIV.Length + encryptedBytes.Length];
            Buffer.BlockCopy(saltKey, 0, result, 0, saltKey.Length);
            Buffer.BlockCopy(saltIV, 0, result, saltKey.Length, saltIV.Length);
            Buffer.BlockCopy(encryptedBytes, 0, result, saltKey.Length + saltIV.Length, encryptedBytes.Length);

            return Convert.ToBase64String(result);
        }


        public string Decrypt(string encrypted)
        {
            if (string.IsNullOrEmpty(_password))
                throw new ArgumentNullException(nameof(_password), "EncryptionSecret not found");

            byte[] encryptedBytes = Convert.FromBase64String(encrypted);

            byte[] saltKey = new byte[16];
            byte[] saltIV = new byte[16];

            Buffer.BlockCopy(encryptedBytes, 0, saltKey, 0, saltKey.Length);
            Buffer.BlockCopy(encryptedBytes, saltKey.Length, saltIV, 0, saltIV.Length);

            Rfc2898DeriveBytes keyBytes = new(_password, saltKey, 1000, HashAlgorithmName.SHA256);
            Rfc2898DeriveBytes ivBytes = new(_password, saltIV, 1000, HashAlgorithmName.SHA256);

            using Aes aes = Aes.Create();
            aes.Key = keyBytes.GetBytes(32);
            aes.IV = ivBytes.GetBytes(16);
            aes.Padding = PaddingMode.PKCS7;

            using MemoryStream ms = new();
            using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            int startPos = saltKey.Length + saltIV.Length;
            cs.Write(encryptedBytes, startPos, encryptedBytes.Length - startPos);
            cs.FlushFinalBlock();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

    }
}