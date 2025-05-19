using eIdentificator.Domain.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace eIdentificator.Application.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        private const int Iterations = 15000;
        private const int HashByteSize = 64;
        private static readonly byte[] Salt = Encoding.UTF8
            .GetBytes("a13b0a52-5c2d-45e6-a28f-f4b872e55db7");
        public string HashPassword(string password)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(
                password, 
                Salt, 
                Iterations, 
                HashAlgorithmName.SHA256
            );
            byte[] hash = pbkdf2.GetBytes(HashByteSize);
            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(
            string inputPassword, 
            string storedPassword
        )
        {
            string inputHash = HashPassword(inputPassword);
            return storedPassword == inputHash;
        }
    }
}
