using boatappapi.Connector;
using boatappapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace boatappapi.Service.User
{
    public class UserService : IUserService
    {
        private DbDoemuDataContext _context;
        public UserService(DbDoemuDataContext context)
        {
            _context = context;
        }
        public IList<UserModel> GetUsers()
        {
            return _context.Users.ToList();
        }

        public UserModel GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
