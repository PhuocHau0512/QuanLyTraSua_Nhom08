using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyTraSua.QuanLyTraSua_DAO; // 
using System.Data;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    // BLL: Business Logic Layer - Xử lý nghiệp vụ
    public class Admin_BLL
    {
        // --- (CHO NGHIEP VU QUAN TRI) ---
        private Admin_DAO adminDAO = new Admin_DAO();

        // --- Cac ham BLL goi DAO ---
        public DataTable GetTablespaceUsage() { return adminDAO.GetTablespaceUsage(); } 
        public DataTable GetActiveSessions() { return adminDAO.GetActiveSessions(); }
        public bool KillSession(int sid, int serial) { return adminDAO.KillSession(sid, serial); }
        public DataTable GetOracleUsers() { return adminDAO.GetOracleUsers(); }
        public DataTable GetOracleRoles() { return adminDAO.GetOracleRoles(); }
        public DataTable GetRolesForUser(string username) { return adminDAO.GetRolesForUser(username); }
        public DataTable GetFGAAuditLog() { return adminDAO.GetFGAAuditLog(); }

        // --- Cac ham BLL co them logic nghiep vu ---
        public bool GrantRole(string username, string rolename)
        {
            // BLL nên kiểm tra dữ liệu đầu vào trước khi gọi DAO
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(rolename)) return false;
            return adminDAO.GrantRole(username, rolename);
        }
        public bool RevokeRole(string username, string rolename)
        {
            // BLL nên kiểm tra dữ liệu đầu vào trước khi gọi DAO
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(rolename)) return false;

            // BLL nên bắt ngoại lệ từ DAO
            try
            {
                // Gọi DAO để thu hồi quyền
                return adminDAO.RevokeRole(username, rolename);
            }
            catch (Exception)
            {
                // Có thể log lỗi ở đây
                return false;
            }
        }
        // Thống kê doanh thu trong khoảng thời gian
        public DataTable GetThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            // Logic nghiệp vụ: Kiểm tra tính hợp lệ của ngày
            if (denNgay < tuNgay)
            {
                // Ném ngoại lệ nếu ngày kết thúc nhỏ hơn ngày bắt đầu
                throw new Exception("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");
            }
            // Gọi DAO để lấy dữ liệu thống kê
            return adminDAO.GetThongKeDoanhThu(tuNgay, denNgay);
        }
    }
}
