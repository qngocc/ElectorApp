
Giải thích:

- `Admin/` — Chứa các mã liên quan tới chức năng quản trị (administrator). Ví dụ: trang quản lý, phân quyền, ...
- `Auth/` — Liên quan tới xác thực, đăng nhập, đăng xuất, bảo mật, có thể là các controller / service xử lý authentication.
- `Models/` — Chứa các lớp mô hình dữ liệu, các đối tượng dùng trong ứng dụng (ví dụ: User, Role, Session,...).
- `Properties/` — Các tệp cấu hình/ metadata của dự án (tùy thuộc cấu hình Visual Studio).
- `Resources/` — Chứa các tài nguyên như file ngôn ngữ, hình ảnh, chuỗi, ...
- `Users/` — Cụ thể hơn để quản lý người dùng: có thể view, controller, dịch vụ liên quan user, phân quyền, etc.
- `bin/Release/net9.0-windows/` & `obj/` — Các thư mục build/biên dịch tạm thời, file thực thi, output ... (không cần commit lên git).
- `ElectorApp.csproj` — file dự án (.NET) chứa các dependency, settings build.
- `ElectorApp.sln` — solution chứa toàn bộ các project/con module nếu mở rộng.
- `Program.cs` — điểm khởi đầu của ứng dụng, cấu hình các services, middleware, route,...
- `UserSession.cs` — xử lý phiên làm việc người dùng (“session”), lưu thông tin đăng nhập, roles, trạng thái user,...

---

## Chức năng / Tính năng chính

Dựa trên cấu trúc và các thư mục hiện có, ElectorApp có các tính năng:

1. **Xác thực người dùng (Authentication)**
   - Cho phép người dùng đăng nhập / đăng xuất.
   - Quản lý session người dùng (UserSession) để giữ trạng thái khi sử dụng ứng dụng.

2. **Phân quyền / quản trị (Authorization / Admin)**
   - Có module Admin để quản lý người dùng, vai trò, có thể kiểm tra quyền trước khi truy cập các phần Admin.
   - Người dùng bình thường / admin có thể có quyền khác nhau khi tương tác với hệ thống.

3. **Mô hình dữ liệu (Models)**
   - Các lớp dữ liệu (ví dụ User, vai trò, session, etc.) dùng để lưu trữ thông tin người dùng, quyền, và các thông tin liên quan.

4. **Giao diện & tương tác (UI / hoặc các controller)**
   - Dự án có phân chia rõ ràng các phần Auth, Admin, Users -> khả năng có các màn hình / khu vực khác nhau cho quản lý người dùng, đăng nhập, hiển thị thông tin người dùng.

---

## Hướng dẫn cài đặt và chạy

1. **Yêu cầu môi trường:**
   - .NET SDK (phiên bản hỗ trợ .NET 9.0)
   - Visual Studio hoặc IDE nào hỗ trợ .NET trên Windows

2. **Chuẩn bị:**
   ```bash
   git clone https://github.com/qngocc/ElectorApp.git
   cd ElectorApp

