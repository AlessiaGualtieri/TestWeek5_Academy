using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week5.Test.Restaurant.MVC.Models
{
    public class UserViewModel
    {
        public int ID_User { get; set; }
        [Required, DataType(DataType.Text), DisplayName("Username")]
        public string Username { get; set; }
        [Required, DataType(DataType.Password), DisplayName("Password")]
        public string Password { get; set; }
        public string ReturnURL { get; set; }
    }
}
