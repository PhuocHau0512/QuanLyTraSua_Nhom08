using QuanLyTraSua.QuanLyTraSua_DAO;
using QuanLyTraSua.QuanLyTraSua_GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    public class HoaDon_BLL
    {
        private HoaDon_DAO hoaDonDAO = new HoaDon_DAO();

        public DataTable GetAllHoaDon()
        {
            return hoaDonDAO.GetAllHoaDon();
        }

        // HÀM MỚI (Bước 6)
        public string KySoHoaDon(string maHD)
        {
            if (string.IsNullOrEmpty(maHD))
            {
                return "Vui lòng chọn một hóa đơn.";
            }
            return hoaDonDAO.KySoHoaDon(maHD);
        }

        // HÀM MỚI (Bước 6)
        public string XacThucHoaDon(string maHD)
        {
            if (string.IsNullOrEmpty(maHD))
            {
                return "Vui lòng chọn một hóa đơn.";
            }
            return hoaDonDAO.XacThucHoaDon(maHD);
        }

        // ** CAP NHAT: Thay doi logic tra ve **
        public string TaoHoaDon(DataTable dtGioHang)
        {
            // --- Logic nghiep vu ---
            if (dtGioHang == null || dtGioHang.Rows.Count == 0)
            {
                return "Giỏ hàng rỗng. Không thể thanh toán.";
            }

            // 1. Tinh TongTien
            double tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTien += Convert.ToDouble(row["ThanhTien"]);
            }

            // 2. Lay MaNV tu Session
            string maNV = Session.MaNV;
            if (string.IsNullOrEmpty(maNV))
            {
                return "Lỗi phiên đăng nhập. Không tìm thấy Mã Nhân Viên.";
            }

            // 3. Tao MaHD (Vi du: HD20251112034530)
            string maHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // 4. Goi DAO de luu (DAO gio tra ve string)
            string ketQuaDAO = hoaDonDAO.TaoHoaDon(maHD, tongTien, maNV, dtGioHang);

            // Tra ve ket qua truc tiep tu DAO (thanh cong hoac bao loi het hang)
            return ketQuaDAO;
        }

        // *** NGHIỆP VỤ MỚI ***
        // Lấy chi tiết hóa đơn
        public DataTable GetChiTietHoaDon(string maHD)
        {
            if (string.IsNullOrEmpty(maHD))
            {
                return null;
            }
            return hoaDonDAO.GetChiTietHoaDon(maHD);
        }
    }
}