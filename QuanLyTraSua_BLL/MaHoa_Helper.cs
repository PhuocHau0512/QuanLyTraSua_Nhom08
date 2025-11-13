using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography; // Thư viện mã hóa

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    // Lớp helper mã hóa
    public class MaHoa_Helper
    {
        // Khóa bí mật dùng cho AES (32 ký tự = 256 bit)
        private static readonly byte[] G_SECRET_KEY = Encoding.UTF8.GetBytes("day-la-key-bi-mat-32-ky-tu-123AB");

        // Mã hóa chuỗi sử dụng AES với khóa bí mật
        public static byte[] EncryptAES(string plainText)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(plainText)) return null;

            byte[] encrypted; // Mảng byte lưu trữ dữ liệu đã mã hóa

            using (Aes aesAlg = Aes.Create()) // Tạo đối tượng AES
            {
                aesAlg.Key = G_SECRET_KEY; // Gán khóa bí mật

                aesAlg.Mode = CipherMode.CBC; // Chế độ mã hóa CBC

                byte[] iv = new byte[16]; // Khởi tạo mảng IV (16 byte = 128 bit)

                Array.Clear(iv, 0, iv.Length); // Khởi tạo IV về 0 (cần đồng bộ khi giải mã)

                aesAlg.IV = iv; // Gán IV

                aesAlg.Padding = PaddingMode.PKCS7; // Chế độ padding PKCS7

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV); // Tạo bộ mã hóa

                using (MemoryStream msEncrypt = new MemoryStream()) // Tạo luồng bộ nhớ để lưu trữ dữ liệu mã hóa
                {
                    // Tạo luồng mã hóa
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        //  Ghi dữ liệu cần mã hóa vào luồng mã hóa
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText); // Ghi chuỗi cần mã hóa
                        }
                        encrypted = msEncrypt.ToArray(); // Lấy mảng byte đã mã hóa từ luồng bộ nhớ
                    }
                }
            }
            return encrypted; // Trả về mảng byte đã mã hóa
        }
    }
}
