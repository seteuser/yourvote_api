using System.Security.Cryptography;
using BrilhaMuito.Factory.Helper;

namespace BrilhaMuito.Factory.Cryptography
{
    public class Sha1 : CryptoBase
    {
        public Sha1()
            : base(new SHA1Managed())
        {
        }

        public override string GenerateSalt(int saltSize)
        {
            return CryptoHelper.GenerateSalt(saltSize);
        }
    }
}