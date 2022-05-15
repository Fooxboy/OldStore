using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OldStore.Backend.Databases;
using OldStore.Backend.Models.Entities;
using OldStore.Backend.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Managers
{
    public class AccountsManager
    {
        private readonly StoreDatabaseContext db;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IdGeneratorService idGenerator;

        public AccountsManager(StoreDatabaseContext db)
        {
            this.db = db;
        }


        public async Task<IdentityResult> CreateUserAsync(RegisterUserModel register)
        {
            var id = idGenerator.GetId();

            var user = new User()
            {
                Id = id,
                UserName = register.UserName,
                Email = register.Email,
            };

            var creationRes = await userManager.CreateAsync(user, register.Password).ConfigureAwait(false);

            return creationRes;

        }

        public async Task<string> LoginUserAsync(LoginUserModel login)
        {
            var user = await userManager.FindByNameAsync(login.UserName).ConfigureAwait(false);

            if (user == null) throw new UserNotFoundException();

            var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, true).ConfigureAwait(false);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut) throw new UserBannedException();


                throw new IncorrectPasswordException();
            }
            var token = await GenerateTokenAsync(user).ConfigureAwait(false);
            return token;

        }

        public async Task<string> GenerateTokenAsync(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JHKFfsdf7dsf9nsdkf9340nsfdk84"));
            var sc = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            var claims = new List<Claim>()
            {
                new Claim("user_id", user.Id.ToString()),
                new Claim("user_name", user.UserName)

            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = "backend",
                IssuedAt = DateTime.Now,
                Issuer = "fluffy",
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = sc,
                Expires = DateTime.UtcNow.AddMonths(3)
            };


            var jwt = tokenHandler.CreateToken(tokenDescriptor);

            //var jwt = new JwtSecurityToken(issuer: "fluffy", audience: "backend", notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMonths(3), claims: claims, signingCredentials: sc);

            var token = tokenHandler.WriteToken(jwt);

            return token;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await db.Users.SingleOrDefaultAsync(u => u.Id == userId).ConfigureAwait(false);

            return user;
        }


        public async Task<List<User>> GetUsersAsync(List<int> userIds)
        {

            var users = await db.Users.Where(u => userIds.Contains(u.Id)).ToListAsync().ConfigureAwait(false);

            return users;
        }

        public async Task<bool> CheckAccount(int userId)
        {
            var result = await db.Users.AnyAsync(u => u.Id == userId).ConfigureAwait(false);

            return result;
        }

    }
}
