using System;
using System.IO;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Preservation.Core.Models;
using Preservation.Core.Utilities;
using Preservation.Crypto.Utilities;

namespace Preservation.Crypto.CryptoLibraries
{
    public class BcgCrypto : CryptoLibBase
    {
        public override KeyPair GenerateKeyPairs(string userName, string password, int encryptionStrength)
        {
            IAsymmetricCipherKeyPairGenerator kpg = new RsaKeyPairGenerator();
            kpg.Init(new RsaKeyGenerationParameters(BigInteger.ValueOf(0x13), new SecureRandom(), encryptionStrength, 8));
            var bcgKeyPair = kpg.GenerateKeyPair();

            var kp = CreateKeyPair(bcgKeyPair.Public, bcgKeyPair.Private, userName, password.ToCharArray());
            kp.UserName = userName;
            kp.EncryptionStrength = encryptionStrength;

            return kp;
        }

        private KeyPair CreateKeyPair(AsymmetricKeyParameter publicKey, AsymmetricKeyParameter privateKey,
            string identity, char[] passPhrase)
        {
            var secretKey = new PgpSecretKey(
                PgpSignature.DefaultCertification,
                PublicKeyAlgorithmTag.RsaGeneral,
                publicKey,
                privateKey,
                DateTime.Now,
                identity,
                SymmetricKeyAlgorithmTag.Cast5,
                passPhrase,
                null,
                null,
                new SecureRandom()
            );

//            secretKey.ExtractPrivateKeyUtf8(passPhrase);
//            var encTest = secretKey.PublicKey.GetEncoded();
//            var theKey = Convert.ToBase64String(encTest);

            return new KeyPair
            {
                PublicKey = CryptoUtils.ArmorKeyBlock(KeyType.Public, Convert.ToBase64String(secretKey.PublicKey.GetEncoded())),
                PrivateKey = CryptoUtils.ArmorKeyBlock(KeyType.Private, Convert.ToBase64String(secretKey.GetEncoded()))
            };
        }
    }
}