using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecurityAPIBackend.Models;

namespace SecurityAPIBackend.Services
{
    public class UserDAL : IUser
    {
        public Task AddUserToRole(string username, string role)
        {
            throw new NotImplementedException();
        }

        public Task<User> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserInRole(string username, string rolename)
        {
            throw new NotImplementedException();
        }

        public Task CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Register(User usr)
        {
            throw new NotImplementedException();
        }
    }
}
