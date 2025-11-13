using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace QuanLyTraSua.QuanLyTraSua_DAO
{
    public class SanPham_DAO
    {
        public DataTable GetSanPhamHistory(string maSP)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;
            string query = @"
                SELECT TenSP, DonGia, 
                       VERSIONS_STARTTIME AS ""Thời điểm Bắt đầu"", 
                       VERSIONS_ENDTIME AS ""Thời điểm Kết thúc"",
                       CASE VERSIONS_OPERATION WHEN 'U' THEN 'Cập nhật' WHEN 'I' THEN 'Thêm mới' ELSE 'Xóa' END AS ""Hành động""
                FROM SANPHAM
                VERSIONS BETWEEN TIMESTAMP (SYSTIMESTAMP - INTERVAL '1' DAY) AND SYSTIMESTAMP
                WHERE MaSP = :maSP
                ORDER BY VERSIONS_STARTTIME DESC NULLS LAST";
            DataTable dataTable = new DataTable();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("maSP", maSP));
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception) { dataTable = null; }
            finally { DataProvider.DongKetNoi(conn); }
            return dataTable;
        }

        public bool RestoreGiaSanPham(string maSP, DateTime timestamp)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {
                using (OracleCommand cmd = new OracleCommand("SP_RestoreGiaSanPham", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_maSP", maSP));
                    cmd.Parameters.Add(new OracleParameter("p_timestamp", OracleDbType.TimeStamp, timestamp, ParameterDirection.Input));
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception) { result = false; }
            finally { DataProvider.DongKetNoi(conn); }
            return result;
        }

        public DataTable GetActiveSanPham()
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;

            // OLS Policy (QLTS_POLICY) se tu dong loc
            // NhanVien (PUB:BH) chi thay TraSua
            // Admin (INT:KHO,BH) thay ca TraSua va Topping
            // ** CAP NHAT: Them SoLuongTon **
            string query = "SELECT MaSP, TenSP, DonGia, SoLuongTon FROM SANPHAM";

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);
            DataProvider.DongKetNoi(conn);
            return dt;
        }

        // Lay TAT CA san pham (Admin co nhan OLS cao nen se thay het)
        public DataTable GetAllSanPham()
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;
            // OLS se tu dong xu ly quyen xem o day
            // ** CAP NHAT: Them SoLuongTon **
            string query = "SELECT MaSP, TenSP, DonGia, LoaiSP, SoLuongTon FROM SANPHAM";
            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);
            DataProvider.DongKetNoi(conn);
            return dt;
        }

        // Ham nay phai chay SP de gan nhan OLS cho san pham moi
        // ** CAP NHAT: Them soLuongTon **
        public bool ThemSanPham(string maSP, string tenSP, double donGia, string loaiSP, int soLuongTon)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {
                using (OracleCommand cmd = new OracleCommand("SP_SanPham_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_MaSP", maSP));
                    cmd.Parameters.Add(new OracleParameter("p_TenSP", tenSP));
                    cmd.Parameters.Add(new OracleParameter("p_DonGia", donGia));
                    cmd.Parameters.Add(new OracleParameter("p_LoaiSP", loaiSP));
                    cmd.Parameters.Add(new OracleParameter("p_SoLuongTon", soLuongTon)); // <-- THEM MOI
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception) { result = false; }
            finally { DataProvider.DongKetNoi(conn); }
            return result;
        }

        // ** CAP NHAT: Them soLuongTon **
        public bool CapNhatSanPham(string maSP, string tenSP, double donGia, string loaiSP, int soLuongTon)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {
                // Khi UPDATE, FGA (Giam sat) se duoc kich hoat neu DonGia thay doi
                // ** CAP NHAT: Them SoLuongTon = :SoLuongTon **
                string query = "UPDATE SANPHAM SET TenSP = :TenSP, DonGia = :DonGia, LoaiSP = :LoaiSP, SoLuongTon = :SoLuongTon WHERE MaSP = :MaSP";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("TenSP", tenSP));
                    cmd.Parameters.Add(new OracleParameter("DonGia", donGia));
                    cmd.Parameters.Add(new OracleParameter("LoaiSP", loaiSP));
                    cmd.Parameters.Add(new OracleParameter("SoLuongTon", soLuongTon)); // <-- THEM MOI
                    cmd.Parameters.Add(new OracleParameter("MaSP", maSP));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception) { result = false; }
            finally { DataProvider.DongKetNoi(conn); }
            return result;
        }

        public bool XoaSanPham(string maSP)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {
                string query = "DELETE FROM SANPHAM WHERE MaSP = :MaSP";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("MaSP", maSP));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception) { result = false; } // Loi co the do rang buoc khoa ngoai tu CTHD
            finally { DataProvider.DongKetNoi(conn); }
            return result;
        }

        // ** HAM MOI (Cho nghiep vu Nhap Kho) **
        public bool NhapKho(string maSP, int soLuongThem)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {
                string query = "UPDATE SANPHAM SET SoLuongTon = SoLuongTon + :SoLuongThem WHERE MaSP = :MaSP";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("SoLuongThem", soLuongThem));
                    cmd.Parameters.Add(new OracleParameter("MaSP", maSP));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception) { result = false; }
            finally { DataProvider.DongKetNoi(conn); }
            return result;
        }

    }
}