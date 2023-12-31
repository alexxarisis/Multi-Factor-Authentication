﻿using System.ComponentModel.DataAnnotations;
using API.Models.Security;

namespace API.Models.User
{
    public class Account
    {
        public string UserName { get;}
        [EmailAddress]
        public string Email { get;}
        public byte[] Password { get;}
        public byte[] Salt { get;}

        public Account(RegisterRequest request)
        {
            UserName = request.UserName;
            Email = request.Email;

            var hasher = new SecurePasswordGenerator();
            Salt = hasher.CreateSalt();
            Password = hasher.HashPassword(request.Password, Salt);
        }
    }
}