using boatappapi.Model;
using System.Collections.Generic;

namespace boatappapi.Service.User
{
    public interface IUserService
    {
        public IList<UserModel> GetUsers();
        public UserModel GetUserByUsername(string username);
    }
}
