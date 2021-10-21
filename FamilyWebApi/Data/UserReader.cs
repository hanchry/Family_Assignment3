﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace FamilyWebApi.Data
{
    public class UserReader : IUserReader
    {
        private FileContext FileContext;
        private IList<User> users;

        public UserReader()
        {
            FileContext = new FileContext();
            users = FileContext.Users;
        }


        public async Task<User> ValidateUserAsync(string username)
        {
            var checkUser = users.FirstOrDefault(user => user.UserName.Equals(username));
            if (checkUser == null)
            {
                throw new Exception("User not found or incorrect username");
            }
            else
            {
                return checkUser;
            }
        }

        public async Task<User> RegisterUserAsync(User userToRegister)
        {
            User checkUser = users.FirstOrDefault(user => user.UserName.Equals(userToRegister.UserName));

            if (checkUser != null)
            {
                throw new Exception("User already exist !");
            }

            users.Add(userToRegister);
            FileContext.SaveChanges();
            return userToRegister;
        }
    }
}