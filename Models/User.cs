using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectorApp.Models
{
    internal class User
    {
     
        public User(int Id, string username, string password, string fullName, bool isAdmin)
        {
            Username = username;
            Id = Id;
            Password = password;
            this.isAdmin = isAdmin;
            FullName = fullName;
        }
        public User(int userId ,string username, string fullName, bool isAdmin)
        {
            this.Id = userId;
            Username = username;
            this.isAdmin = isAdmin;
            FullName = fullName;
        }
        public User() { }

        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public string FullName { get; set; }

    }
}
