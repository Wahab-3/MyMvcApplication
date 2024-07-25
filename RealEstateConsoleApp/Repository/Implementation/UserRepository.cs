using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User user)
        {
            var context = ContextClass.users;
            foreach (var item in context)
            {
                if (item.Email == user.Email)
                {
                    return null;
                }
            }
            context.Add(user);
            return user;

        }

        public List<User> GetAllUser()
        {
            var context = ContextClass.users;
            return context;
        }

        public User GetUserByEmail(string Email)
        {
            var context = ContextClass.users;
            foreach (var item in context)
            {
                if (item.Email == Email)
                {
                    return item;
                }
            }
            return null;
        }
        public User GetUserByEmailAndPassword(string Email, string Password)
        {
            var context = ContextClass.users;
            foreach (var item in context)
            {
                if (item.Email == Email && item.Password == Password)
                {
                    return item;
                }
            }
            return null;
        }
        public User GetUserByRole(string roleName)
        {
            var context = ContextClass.users;
            foreach (var item in context)
            {
                if (item.RoleName == roleName)
                {
                    return item;
                }
            }
            return null;
        }

        public User GetUserById(int id)
        {
            var context = ContextClass.users;
            foreach (var item in context)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}