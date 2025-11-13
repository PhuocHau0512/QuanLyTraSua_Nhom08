using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    public class MaHoa_Helper
    {
        private static readonly byte[] G_SECRET_KEY = Encoding.UTF8.GetBytes("day-la-key-bi-mat-32-ky-tu-123AB");

        public static byte[] EncryptAES(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return null;
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = G_SECRET_KEY;
                aesAlg.Mode = CipherMode.CBC;
                byte[] iv = new byte[16];
                Array.Clear(iv, 0, iv.Length);
                aesAlg.IV = iv;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
    }
}
