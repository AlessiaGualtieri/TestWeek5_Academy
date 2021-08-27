using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5.Test.Restaurant.Core.Models;
using Week5.Test.Restaurant.Core.Repositories;

namespace Week5.Test.Restaurant.Core.EF.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly RestaurantContext ctx;

        public EFUserRepository(RestaurantContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(User item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid user");
            try
            {
                ctx.Users.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> Fetch()
        {
            throw new NotImplementedException();
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            if (String.IsNullOrEmpty(username))
                throw new ArgumentException("Invalid username");
            return ctx.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
