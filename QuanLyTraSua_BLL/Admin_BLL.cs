using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyTraSua.QuanLyTraSua_DAO;
using System.Data;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    public class Admin_BLL
    {
        private Admin_DAO adminDAO = new Admin_DAO();
        public DataTable GetTablespaceUsage() { return adminDAO.GetTablespaceUsage(); }
        public DataTable GetActiveSessions() { return adminDAO.GetActiveSessions(); }
        public bool KillSession(int sid, int serial) { return adminDAO.KillSession(sid, serial); }
        public DataTable GetOracleUsers() { return adminDAO.GetOracleUsers(); }
        public DataTable GetOracleRoles() { return adminDAO.GetOracleRoles(); }
        public DataTable GetRolesForUser(string username) { return adminDAO.GetRolesForUser(username); }
        public DataTable GetFGAAuditLog() { return adminDAO.GetFGAAuditLog(); }

        public bool GrantRole(string username, string rolename)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(rolename)) return false;
            return adminDAO.GrantRole(username, rolename);
        }
        public bool RevokeRole(string username, string rolename)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(rolename)) return false;

            // BLL nên bắt ngoại lệ từ DAO
            try
            {
                return adminDAO.RevokeRole(username, rolename);
            }
            catch (Exception)
            {
                // TODO: Bạn có thể log lỗi ở đây
                return false;
            }
        }
        // --- (CHO NGHIEP VU THONG KE) ---
        public DataTable GetThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            if (denNgay < tuNgay)
            {
                throw new Exception("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");
            }
            return adminDAO.GetThongKeDoanhThu(tuNgay, denNgay);
        }
    }
}
