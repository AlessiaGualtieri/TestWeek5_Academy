using System;
using System.Collections.Generic;
using System.Text;
using Week5.Test.Restaurant.Core.Models;

namespace Week5.Test.Restaurant.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetUser(string username);
    }
}
