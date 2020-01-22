﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PcFruit.Helpers;
using PcFruit.Helpers.Security;
using PcFruit.Models;

namespace PcFruit.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly PcfruitContext _pcFruitContext;

        public UserService(IOptions<AppSettings> appSettings, PcfruitContext pcFruitContext)
        {
            _appSettings = appSettings.Value;
            _pcFruitContext = pcFruitContext;
        }

        public User Authenticate(string email, string password)
        {
            // check if user exists
            var user = _pcFruitContext.Users.SingleOrDefault(x => x.Email == email);
            if (user == null) return null;

            // validate password
            if (!Hash.Validate(password, user.Salt, user.Password))
                return null;
            
            // generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("UserID", user.UserID.ToString()),
                    new Claim("Email", user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // set props that aren't required in the response to null
            user.Password = null;
            user.Salt = null;

            return user;
        }
    }
}
