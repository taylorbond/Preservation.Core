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
            var keys = _cryptoLib.GenerateKeyPairs(_userName, _password, 1024);

            Assert.That(keys.PrivateKey.Contains("Version: Preservation"));
            Assert.That(keys.PrivateKey.Contains("-----BEGIN PGP PRIVATE KEY BLOCK-----"));
            Assert.That(keys.PublicKey.Contains("Version: Preservation"));
            Assert.That(keys.PublicKey.Contains("-----BEGIN PGP PUBLIC KEY BLOCK-----"));
        }

        [Test]
        public void Crypto_GenerateKeys_KeysGeneratedToFile()
        {
            var keys = _cryptoLib.GenerateKeyPairs(_userName, _password, 1024);
            var fileSaveDirectory = $@"C:\temp\{_userName}";

            _cryptoLib.SavePublicAndPrivateKeysToFile(keys, fileSaveDirectory);

            // As long as no exception is raised, the assumption is that the test passes
            Assert.That(keys.PrivateKey.Contains("Version: Preservation"));
            Assert.That(keys.PrivateKey.Contains("-----BEGIN PGP PRIVATE KEY BLOCK-----"));
            Assert.That(keys.PublicKey.Contains("Version: Preservation"));
            Assert.That(keys.PublicKey.Contains("-----BEGIN PGP PUBLIC KEY BLOCK-----"));
            Assert.Pass("Files created.");
        }

        [Test]
        public void Crypto_LoadKeysFromFile_KeysLoaded()
        {
            // TODO: Add your test code here
            Assert.Fail("Test Fails");
        }

        [Test]
        public void Crypto_EncryptMessage_MessageEncrypted()
        {
            // TODO: Add your test code here
            Assert.Fail("Test Fails");
        }

        [Test]
        public void Crypto_DecryptMessage_MessageDecrypted()
        {
            // TODO: Add your test code here
            Assert.Fail("Test Fails");
        }

        [Test]
        public void Crypto_SignMessage_MessageSigned()
        {
            // TODO: Add your test code here
            Assert.Fail("Test Fails");
        }
    }
}