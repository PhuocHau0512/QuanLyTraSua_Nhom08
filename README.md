# 🥤 Dự Án Quản Lý Trà Sữa (Nhóm 8)

## 🧋 Giới thiệu
Dự án này là một ứng dụng **Quản lý Cửa hàng Trà sữa** được xây dựng trên nền tảng **C# Windows Forms** và **Oracle Database**.  
Điểm đặc biệt là dự án tập trung vào **bảo mật nâng cao** với các cơ chế mã hóa, kiểm soát truy cập, giám sát và phục hồi dữ liệu.

---

## 🌟 Tính Năng Nổi Bật (Bảo Mật)

### 1. 🔐 Mã Hóa Dữ Liệu (Encryption)
Ba cơ chế mã hóa được triển khai để bảo vệ dữ liệu nhạy cảm:

#### 🔹 Mã Hóa Đối Xứng (AES 256)
- **Mục tiêu:** Bảo vệ mật khẩu người dùng.  
- **Triển khai:** Mật khẩu trong bảng `TAIKHOAN` được mã hóa bằng AES-256 (CBC, PKCS5) thông qua `PKG_MAHOA`.  
  Việc kiểm tra đăng nhập (`SP_KiemTraDangNhap`) được thực hiện hoàn toàn trong CSDL để mật khẩu không bị truyền qua giữa C# và DB.

#### 🔹 Mã Hóa Bất Đối Xứng (RSA)
- **Mục tiêu:** Bảo vệ thông tin nhạy cảm như số điện thoại.  
- **Triển khai:** Cột `SDT_ENCRYPTED` trong bảng `NHANVIEN` được mã hóa bằng khóa công khai (RSA Public) và chỉ có thể giải mã bằng khóa riêng (RSA Private).

#### 🔹 Mã Hóa Lai (Hybrid: RSA + AES)
- **Mục tiêu:** Bảo vệ dữ liệu có độ dài lớn (Địa chỉ).  
- **Triển khai:**  
  1. Tạo khóa AES 256-bit ngẫu nhiên.  
  2. Mã hóa địa chỉ (`DiaChi`) bằng khóa AES.  
  3. Mã hóa khóa AES bằng khóa RSA Public và lưu vào `DiaChi_Key_Encrypted`.  
  4. Khi giải mã: RSA Private → AES Key → Giải mã dữ liệu.

---

### 2. 🧩 Kiểm Soát Truy Cập (Access Control)

#### 🔹 Phân Quyền (RBAC)
- 3 vai trò chính:  
  - `ROLE_NHANVIEN_BANHANG`  
  - `ROLE_QUANLY_KHO`  
  - `ROLE_ADMIN_HT`
- Mỗi vai trò được cấp quyền chi tiết (SELECT, INSERT, UPDATE) trên các bảng.  
- Form `frmPhanQuyen.cs` cho phép Admin gán hoặc thu hồi quyền người dùng.

#### 🔹 Virtual Private Database (VPD)
- **Mục tiêu:** Giới hạn quyền xem dữ liệu (theo dòng).  
- **Triển khai:** Chính sách `POLICY_HOADON_NHANVIEN` thêm tự động `WHERE MaNV = 'user_hien_tai'` khi nhân viên truy vấn bảng `HOADON`.  
- **Admin:** thấy toàn bộ dữ liệu.

#### 🔹 Oracle Label Security (OLS)
- **Mục tiêu:** Phân loại bảo mật dữ liệu theo nhãn.  
- **Triển khai:** Chính sách `QLTS_POLICY` áp dụng lên bảng `SANPHAM`.  
  - “Trà Sữa” (`TS%`) → PUB:KHO,BH (Công khai).  
  - “Topping” (`TP%`) → INT:KHO (Nội bộ).  
- **Kết quả:** Nhân viên chỉ thấy “Trà Sữa”, Admin thấy tất cả.

---

### 3. 🧭 Giám Sát & Phục Hồi (Auditing & Recovery)

#### 🔹 Fine-Grained Auditing (FGA)
- **Mục tiêu:** Giám sát chi tiết hành vi nhạy cảm.  
- **Triển khai:** Chính sách `FGA_AUDIT_GIASANPHAM` theo dõi SELECT/UPDATE trên cột `DonGia` (bảng `SANPHAM`).  
- Admin xem nhật ký qua form `frmGiamSat.cs`.

#### 🔹 Flashback Technology
- **Mục tiêu:** Phục hồi dữ liệu về trạng thái trước đó.  
- **Triển khai:** Form `frmPhucHoiDuLieu.cs` sử dụng `VERSIONS BETWEEN TIMESTAMP...` để xem lịch sử và gọi `SP_RestoreGiaSanPham` để khôi phục.

---

### 4. 🧾 Tính Toàn Vẹn Dữ Liệu (Data Integrity)

#### 🔹 Chữ Ký Số (Digital Signature)
- **Mục tiêu:** Đảm bảo hóa đơn không bị sửa đổi sau khi tạo.  
- **Triển khai:**  
  - Tạo cặp khóa RSA (2048-bit) và lưu trong `KEY_STORAGE`.  
  - Khi ký số (`SP_KySoHoaDon`): tạo hash, ký bằng Private Key, lưu vào `ChuKySo`.  
  - Khi xác thực (`SP_XacThucHoaDon`): dùng Public Key xác minh — nếu thay đổi dữ liệu → xác thực thất bại.

---

### 5. ⚙️ Chính Sách CSDL (Database Policy)
- **Profile:** `NV_TRA_SUA_PROFILE` giới hạn tài nguyên người dùng.  
- **Chính sách mật khẩu:** Khóa tài khoản sau **3 lần đăng nhập thất bại** (`FAILED_LOGIN_ATTEMPTS = 3`).

---

## 🏗️ Cấu Trúc Dự Án (3-Layer Architecture)

### 1. `QuanLyTraSua_GUI` (Lớp giao diện)
- Các form: `frmDangNhap`, `frmBanHang`, `frmSanPham`, `frmPhanQuyen`...  
- Xử lý tương tác người dùng, hiển thị dữ liệu.

### 2. `QuanLyTraSua_BLL` (Lớp nghiệp vụ)
- Chứa các lớp xử lý logic nghiệp vụ như `SanPham_BLL`, `TaiKhoan_BLL`.  
- Kiểm tra dữ liệu trước khi gửi xuống DAO.

### 3. `QuanLyTraSua_DAO` (Lớp truy cập dữ liệu)
- Kết nối trực tiếp với Oracle qua `DataProvider.cs` và `Oracle.ManagedDataAccess.Client`.  
- Gọi Stored Procedure, thực thi truy vấn SQL.

### 4. `QuanLyTraSua_DTO` (Lớp đối tượng truyền dữ liệu)
- Các lớp POJO như `TaiKhoan_DTO`, `SanPham_DTO` để truyền dữ liệu giữa tầng GUI – BLL – DAO.

---

## 🛠️ Công Nghệ Sử Dụng
| Hạng mục | Công nghệ |
|-----------|------------|
| Ngôn ngữ | C# |
| Nền tảng | .NET Framework 4.7.2 |
| Giao diện | Windows Forms |
| CSDL | Oracle Database |
| Kết nối | ADO.NET (`Oracle.ManagedDataAccess.Client`) |

---

## 🚀 Hướng Dẫn Cài Đặt

### 1. Cài Đặt Cơ Sở Dữ Liệu Oracle
Các file trong thư mục `QuanLyTraSua_DATABASE/`:

1. `00_DON_DEP_AS_SYSDBA.txt` – Dọn dẹp user QLTS (tùy chọn).  
2. `01_RUN_AS_SYSDBA.txt` – Tạo user `QLTS` và cấp quyền (LBAC_DBA, DBMS_CRYPTO, DBMS_RLS...).  
3. `02_RUN_AS_QLTS.txt` – Tạo bảng, chèn dữ liệu mẫu, package, procedure, policy (VPD, OLS, FGA).

---

### 2. Cài Đặt Ứng Dụng C#
- Mở `QuanLyTraSua.sln` bằng Visual Studio.  
- Cập nhật chuỗi kết nối trong `App.config`:
```bash
```xml
<connectionStrings>
  <add name="OracleDB"
       connectionString="Data Source=localhost:1521/ORCL;User Id=QLTS;Password=qlts;"
       providerName="Oracle.ManagedDataAccess.Client" />
</connectionStrings>
```

🔑 Tài Khoản Mặc Định

| Loại |	Username |	Password |	Quyền |
|-----------|------------|-----------|------------|
| Admin	| admin	| 123	| Toàn quyền: xem tất cả hóa đơn, sản phẩm |
| Nhân viên	| binhtt | 123	| Bị giới hạn bởi VPD (theo MaNV) và OLS (sản phẩm Trà Sữa) |

📚 Tác Giả

Nhóm 8 – Trường Đại học Công Thương TP.HCM
| STT | Họ và tên | Mã số sinh viên |
|-----------|------------|------------|
| 7 | Ngô Thanh Duy | 2033230045 |
| 11 | Lê Phước Hậu | 2033221314 |
| 40 | Bùi Thị Vấn | 2001231031 |

📦 Ghi chú thêm

1. Tất cả mã nguồn, script SQL và tài liệu hướng dẫn đều nằm trong thư mục gốc của dự án.

2. Có thể mở rộng sang phiên bản WPF hoặc ASP.NET trong tương lai.

3. Cấu hình tương thích với Oracle 12c trở lên.
