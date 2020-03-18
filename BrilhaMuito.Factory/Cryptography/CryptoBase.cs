using System;
using System.Security.Cryptography;
using System.Text;
using BrilhaMuito.Factory.Helper;

namespace BrilhaMuito.Factory.Cryptography
{
    public abstract class CryptoBase
    {
        private readonly HashAlgorithm _algorithm;

        protected CryptoBase(HashAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public abstract string GenerateSalt(int saltSize);

        public virtual string Generate(string plainText)
        {
            byte[] plainTextBytes = Encoding.ASCII.GetBytes(plainText);

            byte[] hash = _algorithm.ComputeHash(plainTextBytes);

            return Convert.ToBase64String(hash);
        }

        public virtual string GenerateSalted(string plainText, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] plainTextBytes = Encoding.ASCII.GetBytes(plainText);

            byte[] plainTextWithSaltBytes = CryptoHelper.AppendByteArray(plainTextBytes, saltBytes);

            byte[] saltedSHA1Bytes = _algorithm.ComputeHash(plainTextWithSaltBytes);

            byte[] saltedSHA1WithAppendedSaltBytes = CryptoHelper.AppendByteArray(saltedSHA1Bytes, saltBytes);

            return Convert.ToBase64String(saltedSHA1WithAppendedSaltBytes);
        }
    }
}