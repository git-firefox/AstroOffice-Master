using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Utilities
{
    
    public class ENCEK
    {
        public static string CellGell_ENC(string st, string pwd)
        {
            string str = pwd != "cellgell.com" ? "Invalid" : ENC(st, "xmasala!$^&", "nikah@r@m!mma$#", "SHA1", 2, "@1C9cEx4e1F8g7H8", 256);
            return str;
        }

        public static string CellGell_ENC_RET(string st, string pwd)
        {
            string str = pwd != "kisanpepsi" ? "Invalid" : ENC(st, "xxxmasacdla!$^&", "nikah@r@m!eea$#", "SHA1", 2, "@1C9cEx4e1F8g7H8", 256);
            return str;
        }

        public static bool CellGell_MilaKya(string plainText, string encText, string pwd)
        {
            bool flag = false;
            if (pwd == "cellgell.com")
            {
                flag = plainText == DEC(encText, "xmasala!$^&", "nikah@r@m!mma$#", "SHA1", 2, "@1C9cEx4e1F8g7H8", 256);
            }
            return flag;
        }

        public static string CellGell_Ret(string plainText, string encText, string pwd)
        {
            string str = pwd != "kisanpepsi" ? "Invalid" : DEC(encText, "xxxmasacdla!$^&", "nikah@r@m!eea$#", "SHA1", 2, "@1C9cEx4e1F8g7H8", 256);
            return str;
        }

        private static string DEC(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

            using (Aes aes = Aes.Create())
            {
                aes.Key = passwordDeriveByte.GetBytes(keySize / 8); ;
                aes.IV = Encoding.ASCII.GetBytes(initVector);
                aes.Mode = CipherMode.CBC;

                ICryptoTransform cryptoTransform = aes.CreateDecryptor();

                using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
                    {
                        byte[] decryptedBytes = new byte[cipherTextBytes.Length];

                        int num = 0;
                        try
                        {
                            num = cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                        }
                        catch { }

                        return Encoding.UTF8.GetString(decryptedBytes, 0, num);
                    }
                }
            }
        }

        private static string ENC(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes passwordDeriveByte = new(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

            using (Aes aes = Aes.Create())
            {
                aes.Key = passwordDeriveByte.GetBytes(keySize / 8); ;
                aes.IV = Encoding.ASCII.GetBytes(initVector);
                aes.Mode = CipherMode.CBC;

                ICryptoTransform cryptoTransform = aes.CreateEncryptor();

                using (MemoryStream memoryStream = new())
                {
                    using (CryptoStream cryptoStream = new(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        byte[] bytes = memoryStream.ToArray();
                        return Convert.ToBase64String(bytes);
                    }
                }
            }
        }
    }
}
