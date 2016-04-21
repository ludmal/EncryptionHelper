namespace EncryptionHelper
{
    public static class EncryptionHelperExtentions
    {
        /// <summary>
        /// Decrypts the string if encrypted
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decrypt(this string text)
        {
            return CryptoHelper.Decrypt(text);
        }

        /// <summary>
        /// Encrypt the string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(this string text)
        {
            return CryptoHelper.Encrypt(text);
        }
    }
}