using System;
using System.Text;
using System.Security.Cryptography;

namespace Web.Util
{
    public class Security
    {
        #region Methods
        public static string Encrypt(string keyToEncrypt, string key)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string keyTemp = key;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(keyTemp));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; 
                byteBuff = ASCIIEncoding.ASCII.GetBytes(keyToEncrypt);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }

            catch (Exception ex)
            {
                return "Encrypt Failed. " + ex.Message;
            }
        }

        public static string EncryptToken(string keyToEncrypt, string key)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string keyTemp = key;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(keyTemp));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB;
                byteBuff = ASCIIEncoding.ASCII.GetBytes(keyToEncrypt);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }

            catch (Exception ex)
            {
                return "Token Failed. " + ex.Message;
            }
        }

        public static dynamic GenerateToken(string key)
        {
            Random random = new Random();
            int tokenNumber = random.Next();
            string tokenKey = Convert.ToString(tokenNumber);

            // Generate Authentication Token 
            var token = Security.EncryptToken(key, tokenKey);
            return token;
        }
        #endregion 
    }
}