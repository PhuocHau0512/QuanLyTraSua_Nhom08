using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using QuanLyTraSua.QuanLyTraSua_GUI;

namespace QuanLyTraSua.QuanLyTraSua_DAO
{
    public class DataProvider
    {
        private static string connectionString = "Data Source=localhost:1521/ORCL;User Id=QLTS;Password=qlts;";

        private static void SetSessionContext(OracleConnection conn)
        {
            // Kiểm tra cả 3 thông tin Session
            if (!string.IsNullOrEmpty(Session.MaNV) &&
                !string.IsNullOrEmpty(Session.Quyen) &&
                !string.IsNullOrEmpty(Session.OlsLabel))
            {
                try
                {
                    // 1. Set VPD Context (cho POLICY_HOADON_NHANVIEN)
                    using (OracleCommand cmdVPD = new OracleCommand("PKG_VPD_CONTEXT.SP_SET_CONTEXT", conn))
                    {
                        cmdVPD.CommandType = CommandType.StoredProcedure;
                        cmdVPD.Parameters.Add(new OracleParameter("p_manv", Session.MaNV));
                        cmdVPD.Parameters.Add(new OracleParameter("p_quyen", Session.Quyen));
                        cmdVPD.ExecuteNonQuery();
                    }

                    // 2. Set OLS Label (cho QLTS_POLICY)
                    // (Yêu cầu SYS đã chạy: GRANT EXECUTE ON SA_SESSION TO QLTS;)
                    using (OracleCommand cmdOLS = new OracleCommand("SA_SESSION.SET_LABEL", conn))
                    {
                        cmdOLS.CommandType = CommandType.StoredProcedure;
                        cmdOLS.Parameters.Add(new OracleParameter("policy_name", "QLTS_POLICY"));
                        cmdOLS.Parameters.Add(new OracleParameter("label", Session.OlsLabel));
                        cmdOLS.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi nếu quyền chưa được cấp (ví dụ: SA_SESSION)
                }
            }
        }

        public static OracleConnection MoKetNoi()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                conn.Open();
                SetSessionContext(conn); // Tự động set context cho VPD và OLS
                return conn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void DongKetNoi(OracleConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public static DataTable ThucThiTruyVan(string query, OracleConnection conn)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception) { dataTable = null; }
            return dataTable;
        }

        public static bool ThucThiPhiTruyVan(string query, OracleConnection conn)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}