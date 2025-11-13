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
    // BLL: Business Logic Layer - Xử lý nghiệp vụ
    public class HoaDon_BLL // BLL cho Quản lý Hóa Đơn
    {
        private HoaDon_DAO hoaDonDAO = new HoaDon_DAO();

        public DataTable GetAllHoaDon() // Lấy tất cả hóa đơn
        {
            return hoaDonDAO.GetAllHoaDon();
        }

        // Ký số hóa đơn
        public string KySoHoaDon(string maHD)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(maHD))
            {
                return "Vui lòng chọn một hóa đơn.";
            }
            // Gọi DAO để ký số
            return hoaDonDAO.KySoHoaDon(maHD);
        }

        // Xác thực hóa đơn
        public string XacThucHoaDon(string maHD)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(maHD))
            {
                return "Vui lòng chọn một hóa đơn.";
            }
            // Gọi DAO để xác thực
            return hoaDonDAO.XacThucHoaDon(maHD);
        }

        // Tạo hóa đơn mới
        public string TaoHoaDon(DataTable dtGioHang)
        {
            // Kiem tra gio hang
            if (dtGioHang == null || dtGioHang.Rows.Count == 0)
            {
                return "Giỏ hàng rỗng. Không thể thanh toán.";
            }

            // 1. Tinh tong tien
            double tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTien += Convert.ToDouble(row["ThanhTien"]);
            }

            // 2. Lay maNV tu Session
            string maNV = Session.MaNV;
            if (string.IsNullOrEmpty(maNV))
            {
                return "Lỗi phiên đăng nhập. Không tìm thấy Mã Nhân Viên.";
            }

            // 3. Tao MaHD (Vi du: HD20251112034530)
            // Ma hoa don theo thoi gian hien tai
            string maHD = "HD" + DateTime.Now.ToString("yyMMddHHmmss");

            // 4. Goi DAO de luu (DAO gio tra ve string)
            // Tra ve thong diep thanh cong hoac loi het hang
            string ketQuaDAO = hoaDonDAO.TaoHoaDon(maHD, tongTien, maNV, dtGioHang);

            // Tra ve ket qua truc tiep tu DAO (thanh cong hoac bao loi het hang)
            return ketQuaDAO;
        }

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