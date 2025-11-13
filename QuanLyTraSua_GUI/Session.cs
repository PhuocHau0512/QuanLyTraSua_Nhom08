using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTraSua.QuanLyTraSua_GUI;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    public class Session
    {
        public static string MaNV { get; set; }
        public static string Quyen { get; set; }
        public static string OlsLabel { get; set; } // <-- THÊM DÒNG NÀY (Bước 8)

        public static void Clear()
        {
            MaNV = null;
            Quyen = null;
            OlsLabel = null; // <-- THÊM DÒNG NÀY (Bước 8)
        }
    }
}