using BarManagment.Application.Core.Abstractions.Cryptography;
using BarManagment.Domain.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace BarManagment.Infrastructure.Cryptography
{
    internal class PasswordHasher : IPasswordHasher, IPasswordHashChecker
    {
        private const KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA256;
        private const int IterationCount = 10000;
        private const int NumberOfBytesRequested = 256 / 8;
        private const int SaltSize = 128 / 8;

        public string HashPassword(string password)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            string hashedPassword = Convert.ToBase64String(HashPasswordInternal(password));

            return hashedPassword;
        }
        private byte[] HashPasswordInternal(string password)
        {
            byte[] salt = GetRandomSalt();

            byte[] subKey = KeyDerivation.Pbkdf2(password, salt, Prf, IterationCount, NumberOfBytesRequested);

            byte[] outputBytes = new byte[salt.Length + subKey.Length];

            Buffer.BlockCopy(salt, 0, outputBytes, 0, salt.Length);

            Buffer.BlockCopy(subKey, 0, outputBytes, salt.Length, subKey.Length);

            return outputBytes;
        }
        private byte[] GetRandomSalt()
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            return salt;
        }

        public bool HashesMatch(string passwordHash, string providedPassword)
        {
            if (passwordHash is null)
            {
                throw new ArgumentNullException(nameof(passwordHash));
            }

            if (providedPassword is null)
            {
                throw new ArgumentNullException(nameof(providedPassword));
            }

            byte[] decodedHashedPassword = Convert.FromBase64String(passwordHash);

            if (decodedHashedPassword.Length == 0)
            {
                return false;
            }

            bool verified = VerifyPasswordHashInternal(decodedHashedPassword, providedPassword);

            return verified;
        }

        private static bool VerifyPasswordHashInternal(byte[] hashedPassword, string password)
        {
            try
            {
                byte[] salt = new byte[SaltSize];

                Buffer.BlockCopy(hashedPassword, 0, salt, 0, salt.Length);

                int subKeyLength = hashedPassword.Length - salt.Length;

                if (subKeyLength < SaltSize)
                {
                    return false;
                }

                byte[] expectedSubKey = new byte[subKeyLength];

                Buffer.BlockCopy(hashedPassword, salt.Length, expectedSubKey, 0, expectedSubKey.Length);

                byte[] actualSubKey = KeyDerivation.Pbkdf2(password, salt, Prf, IterationCount, subKeyLength);

                return ByteArraysEqual(actualSubKey, expectedSubKey);
            }
            catch
            {
                return false;
            }
        }
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            bool areSame = true;

            for (int i = 0; i < a.Length; i++)
            {
                areSame &= a[i] == b[i];
            }

            return areSame;
        }
    }
}
