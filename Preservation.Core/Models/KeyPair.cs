namespace Preservation.Core.Models
{
    public class KeyPair
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string UserName { get; set; }
        public int EncryptionStrength { get; set; }
    }
}