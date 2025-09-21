using ElectorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectorApp
{
    internal static class UserSession
    {
        public static string Username { get; set; }
        public static int Id { get; set; }
        public static string FullName { get; set; }

        public static bool IsAdmin = false; // truong de kiem tra quyen admin hay user
        public static bool IsLoggedIn { get; set; } = false; // truong de kiem tra trang thai dang nhap
        public static void Logout() // sau khi dang xuat xoa toan bo thong tin user dang nhap
        {
            Id = 0;
            Username = null;
            FullName = null;
            IsLoggedIn = false;
            IsAdmin = false;
        }
        public static void Login(User user) // sau khi dang nhap gan thong tin user vao cac truong
        {
            Username = user.Username;
            Id = user.Id;
            FullName = user.FullName;
            IsLoggedIn = true;
            IsAdmin = user.isAdmin;
        }
    }
}
