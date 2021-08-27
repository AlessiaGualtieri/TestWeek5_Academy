using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Test.Restaurant.Core.Models
{
    public class User
    {
        public int ID_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsOwner { get; set; }

        public string Role()
        {
            return (this.IsOwner) ? "Owner" : "User";
        }
    }
}
