using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    internal class User
    {
        public string userName { get; set; }
        public string password { get; set; }

        public User(string userName, string password)
        {
            userName = userName;
            password = password;
        }
    }
}
