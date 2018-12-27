using NUnit.Framework;
using Preservation.Crypto.CryptoLibraries;

namespace Preservation.Core.Tests
{
    [TestFixture]
    public class CryptoTests
    {
        private BcgCrypto _cryptoLib;
        private string _userName;
        private string _password;

        [SetUp]
        public void Initialize()
        {
            _cryptoLib = new BcgCrypto();
            _userName = "test@mytest.com";
            _password = "myTestPassword";
        }

        [Test]
        public void Crypto_GenerateKeys_KeysGeneratedInMemory()
        {
            var userName = "test@mytest.com";
            var password = "myTestPassword";

            var keys = _cryptoLib.GenerateKeyPairs(_userName, _password, 1024);

            Assert.That(keys.PrivateKey.Contains("Version: Preservation"));
            Assert.That(keys.PrivateKey.Contains("-----BEGIN PGP PRIVATE KEY BLOCK-----"));
            Assert.That(keys.PublicKey.Contains("Version: Preservation"));
            Assert.That(keys.PublicKey.Contains("-----BEGIN PGP PUBLIC KEY BLOCK-----"));
        }
    }
}