namespace Preservation.Core.Utilities
{
    public static class StringUtils
    {
        public static string ConvertBytesToString(byte[] input)
        {
            return System.Text.Encoding.ASCII.GetString(input);
        }
    }
}
