using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    class User
    {
        public string Name { get; set; }
        public string Second_Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set;}
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string name, string sname, string surname, string email, string phone, string username, string pass)
        {
            Name = name;
            Second_Name = sname;
            Surname = surname;
            Email = email;
            Phone = phone;
            UserName = username;
            Password = pass;
        }
        
    }
}
