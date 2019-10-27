using System.Collections.Generic;
using ChatAPI.Models.Result;

namespace ChatAPI.Auth
{
    public interface IUserService
    {
          Users Authenticate(string username, string password);
        List<string> GetAll();
    }
}