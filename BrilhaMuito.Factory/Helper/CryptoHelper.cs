using System;
using System.Security.Cryptography;

namespace BrilhaMuito.Factory.Helper
{
    public static class CryptoHelper
    {
        public static string GenerateSalt(int saltSize)
        {
            var rng = new RNGCryptoServiceProvider();

            var buff = new byte[saltSize];

            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        public static byte[] AppendByteArray(byte[] byteArray1, byte[] byteArray2)
        {
            var byteArrayResult = new byte[byteArray1.Length + byteArray2.Length];

            for (var i = 0; i < byteArray1.Length; i++)
            {
                byteArrayResult[i] = byteArray1[i];
            }

            for (var i = 0; i < byteArray2.Length; i++)
            {
                byteArrayResult[byteArray1.Length + i] = byteArray2[i];
            }

            return byteArrayResult;
        }
    }
}