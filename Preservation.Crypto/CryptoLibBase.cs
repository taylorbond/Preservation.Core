using Preservation.Core.Models;

namespace Preservation.Crypto
{
    public abstract class CryptoLibBase
    {
        public abstract KeyPair GenerateKeyPairs(string userName, string password, int encryptionStrength);
    }
}