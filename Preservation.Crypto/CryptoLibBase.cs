using System.IO;
using Preservation.Core.Models;

namespace Preservation.Crypto
{
    public abstract class CryptoLibBase
    {
        public abstract KeyPair GenerateKeyPairs(string userName, string password, int encryptionStrength);

        public void SavePublicAndPrivateKeysToFile(KeyPair keys, string fileSaveDirectory)
        {
            SavePublicKeyToFile(keys.PublicKey, fileSaveDirectory);
            SavePrivateKeyToFile(keys.PrivateKey, fileSaveDirectory);
        }

        public void SavePublicKeyToFile(string key, string fileSaveDirectory)
        {
            var outputStream = new FileInfo($"{fileSaveDirectory}-pub.asc").OpenWrite();

            SaveFile(key, outputStream);

            outputStream.Close();
        }

        public void SavePrivateKeyToFile(string key, string fileSaveDirectory)
        {
            var outputStream = new FileInfo($"{fileSaveDirectory}-private.asc").OpenWrite();

            SaveFile(key, outputStream);

            outputStream.Close();
        }

        private void SaveFile(string data, FileStream fileStream)
        {
            var streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(data);
            streamWriter.Close();
        }
    }
}