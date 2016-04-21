using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionHelper
{
    /// <summary>
    /// Encrypt/Decrypt given string value
    /// </summary>
    public class CryptoHelper
    {
        private const string VectorId = "w48*+-36dfthjklo";

        private static readonly string KeyId = ConfigurationManager.AppSettings["EncryptionKey"] ??
                                                "!@#$%^&*()AX826Gwkf58e?s";
        /// <summary>
        /// Decrypts the string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decrypt(string text)
        {
            var memStreamDecryptedData = new MemoryStream();

            var rij = default(Rijndael);
            rij = new RijndaelManaged {Mode = CipherMode.CBC};

            var transform = rij.CreateDecryptor(Encoding.ASCII.GetBytes(KeyId), Encoding.ASCII.GetBytes(VectorId));
            var decStream = new CryptoStream(memStreamDecryptedData, transform, CryptoStreamMode.Write);
            var bytesData = Convert.FromBase64String(text);
            try
            {
                decStream.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while writing encrypted data to the stream:" + ex.Message);
            }
            decStream.FlushFinalBlock();
            decStream.Close();

            return Encoding.ASCII.GetString(memStreamDecryptedData.ToArray());
        }

        /// <summary>
        /// Encrypts the string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            var memStreamEncryptedData = new MemoryStream();
            var rij = default(Rijndael);
            rij = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Key = Encoding.ASCII.GetBytes(KeyId),
                IV = Encoding.ASCII.GetBytes(VectorId)
            };


            var bytesData = Encoding.ASCII.GetBytes(text);

            var transform = rij.CreateEncryptor();
            var encStream = new CryptoStream(memStreamEncryptedData, transform, CryptoStreamMode.Write);

            try
            {
                encStream.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while writing encrypted data to the stream:" + ex.Message);
            }

            encStream.FlushFinalBlock();
            encStream.Close();

            return Convert.ToBase64String(memStreamEncryptedData.ToArray());
        }
    }

}