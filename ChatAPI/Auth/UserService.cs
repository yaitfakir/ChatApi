using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ChatAPI.Context;
using ChatAPI.Helpers;
using ChatAPI.Models.Result;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChatAPI.Auth
{
    public class UserService : IUserService
    {
        private testContext _context;
        private readonly AppSettings _appSettings;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        public UserService(IOptions<AppSettings> appSettings, testContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;

        }

        public Users Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Login == username && x.Pass == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Tokens = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Pass = null;

            return user;
        }

        public List<string> GetAll()
        {
            // return users without passwords
            return _context.Users.Select(x => x.Name).ToList();
        }
    }
}
