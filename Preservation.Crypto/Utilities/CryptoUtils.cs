using System.Diagnostics;
using System.Reflection;
using Preservation.Core.Models;

namespace Preservation.Crypto.Utilities
{
    public static class CryptoUtils
    {
        public static string ArmorKeyBlock(KeyType keyType, string key)
        {
            var keyTypeString = keyType == KeyType.Private ? "PRIVATE" : "PUBLIC";
            var header = "-----BEGIN PGP " + keyTypeString + " KEY BLOCK-----";
            var footer = "-----END PGP " + keyTypeString + " KEY BLOCK-----";
            var version = "Version: Preservation v" + GetAssemblyVersion();

            return header + "\n" + version + "\n\n" + key + "\n" + footer;
        }

        private static string GetAssemblyVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }
    }
}