using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client; // Thư viện Oracle
using System.Data;

namespace QuanLyTraSua.QuanLyTraSua_DAO
{
    // DAO dành cho các chức năng quản trị hệ thống
    public class Admin_DAO
    {
        // Thống kê dung lượng tablespace
        public DataTable GetTablespaceUsage()
        {
            OracleConnection conn = DataProvider.MoKetNoi(); 

            if (conn == null) return null; 

            // Truy vấn thống kê dung lượng tablespace
            string query = @"
                SELECT 
                    fs.tablespace_name AS ""Tablespace"",
                    (df.total_space_mb - fs.free_space_mb) AS ""Đã dùng (MB)"",
                    fs.free_space_mb AS ""Còn trống (MB)"",
                    df.total_space_mb AS ""Tổng (MB)"",
                    ROUND(((df.total_space_mb - fs.free_space_mb) / df.total_space_mb) * 100, 2) AS ""Tỷ lệ dùng (%)""
                FROM (SELECT tablespace_name, ROUND(SUM(bytes) / 1024 / 1024) AS free_space_mb
                     FROM dba_free_space GROUP BY tablespace_name) fs,
                     (SELECT tablespace_name, ROUND(SUM(bytes) / 1024 / 1024) AS total_space_mb
                     FROM dba_data_files GROUP BY tablespace_name) df
                WHERE fs.tablespace_name = df.tablespace_name
                  AND fs.tablespace_name = 'TS_QUANLYTRASUA'";

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn); 

            DataProvider.DongKetNoi(conn); 

            return dt;
        }

        // Lấy danh sách phiên làm việc hiện tại
        public DataTable GetActiveSessions()
        {
            OracleConnection conn = DataProvider.MoKetNoi(); 

            if (conn == null) return null; 

            // Truy vấn lấy danh sách phiên làm việc
            string query = @"
                SELECT sid AS ""SID"", serial# AS ""Serial"", username AS ""User"", 
                       osuser AS ""OS User"", machine AS ""Máy trạm"", program AS ""Chương trình"",
                       TO_CHAR(logon_time, 'DD/MM/YYYY HH24:MI:SS') AS ""Thời gian""
                FROM v$session
                WHERE username IS NOT NULL";

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn); 

            DataProvider.DongKetNoi(conn);

            return dt;
        }

        // Kết thúc phiên làm việc
        public bool KillSession(int sid, int serial)
        {
            OracleConnection conn = DataProvider.MoKetNoi();

            if (conn == null) return false; 

            bool result = false; // Biến kết quả
                                 // Thực thi thủ tục lưu trữ để kết thúc phiên làm việc
            try
            {
                // Sử dụng OracleCommand để gọi thủ tục lưu trữ
                using (OracleCommand cmd = new OracleCommand("SP_Admin_KillSession", conn))
                {
                    // Đặt kiểu lệnh là thủ tục lưu trữ
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số cho thủ tục
                    cmd.Parameters.Add(new OracleParameter("p_sid", sid));
                    cmd.Parameters.Add(new OracleParameter("p_serial", serial));

                    // Thực thi lệnh
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception) 
            { 
                result = false; 
            }
            finally 
            { 
                DataProvider.DongKetNoi(conn); 
            }
            return result;
        }

        // Lấy danh sách người dùng Oracle
        public DataTable GetOracleUsers()
        {
            OracleConnection conn = DataProvider.MoKetNoi();

            if (conn == null) return null;

            // Truy vấn lấy danh sách người dùng
            string query = "" +
                "SELECT USERNAME " +
                "FROM dba_users " +
                "WHERE ORACLE_MAINTAINED = 'N' AND USERNAME NOT LIKE 'APEX_%' ORDER BY USERNAME";

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);

            DataProvider.DongKetNoi(conn);

            return dt;
        }
        // Lấy danh sách vai trò Oracle
        public DataTable GetOracleRoles()
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;

            // Truy vấn lấy danh sách vai trò
            string query = "" +
                "SELECT ROLE " +
                "FROM dba_roles " +
                "WHERE ROLE LIKE 'ROLE_%' ORDER BY ROLE";

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);

            DataProvider.DongKetNoi(conn);

            return dt;
        }

        // Lấy các vai trò được gán cho người dùng
        public DataTable GetRolesForUser(string username)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;

            // Truy vấn lấy các vai trò được gán cho người dùng
            string query = "SELECT GRANTED_ROLE " +
                "FROM dba_role_privs " +
                "WHERE GRANTEE = :username";

            DataTable dataTable = new DataTable();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Thêm tham số vào Command
                    cmd.Parameters.Add(new OracleParameter("username", username));

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            catch (Exception) 
            { 
                dataTable = null; 
            }
            finally 
            { 
                DataProvider.DongKetNoi(conn); 
            }

            return dataTable;
        }

        public bool GrantRole(string username, string rolename)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {
                using (OracleCommand cmd = new OracleCommand("SP_Admin_GrantRole", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_username", username));
                    cmd.Parameters.Add(new OracleParameter("p_rolename", rolename));
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception) { result = false; }
            finally { DataProvider.DongKetNoi(conn); }
            return result;
        }

        public bool RevokeRole(string username, string rolename)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;

            // Không cần try-catch ở đây
            try
            {
                using (OracleCommand cmd = new OracleCommand("SP_Admin_RevokeRole", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_username", username));
                    cmd.Parameters.Add(new OracleParameter("p_rolename", rolename));
                    cmd.ExecuteNonQuery();
                    return true; // Trả về true nếu thành công
                }
            }
            // catch (Exception) { result = false; } // Xóa khối catch này
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
            // (Code sẽ không bao giờ tới đây nếu có lỗi, vì nó đã ném ngoại lệ)
        }

        public DataTable GetFGAAuditLog()
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;
            string query = @"
                SELECT TO_CHAR(TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS ""Thời gian"",
                       DB_USER AS ""User"", OS_USER AS ""Máy trạm"", SQL_TEXT AS ""Câu lệnh""
                FROM DBA_FGA_AUDIT_TRAIL 
                WHERE POLICY_NAME = 'FGA_AUDIT_GIASANPHAM'
                ORDER BY TIMESTAMP DESC";
            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);
            DataProvider.DongKetNoi(conn);
            return dt;
        }

        // --- HAM MOI (CHO NGHIEP VU THONG KE) ---
        public DataTable GetThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;
            DataTable dt = new DataTable();
            try
            {
                using (OracleCommand cmd = new OracleCommand("SP_ThongKe_DoanhThu", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_TuNgay", OracleDbType.Date, tuNgay, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("p_DenNgay", OracleDbType.Date, denNgay, ParameterDirection.Input));

                    OracleParameter p_cursor = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add(p_cursor);

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception) { dt = null; }
            finally { DataProvider.DongKetNoi(conn); }
            return dt;
        }
    }
}