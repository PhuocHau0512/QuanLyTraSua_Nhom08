using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.QuanLyTraSua_DTO
{
    public class TaiKhoan_DTO
    {
        public string TenTK { get; set; }
        public byte[] MatKhau { get; set; } // Dạng đã mã hóa AES
        public string MaNV { get; set; }
        public string Quyen { get; set; }
    }
}