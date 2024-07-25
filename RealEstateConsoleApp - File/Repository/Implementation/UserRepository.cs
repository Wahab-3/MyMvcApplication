using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateConsoleApp.Models;
using RealEstateConsoleApp___File;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        string FilePath = "C:\\Users\\USER\\Desktop\\PogrammingProjects\\RealEstateConsoleApp - File\\DbFolder\\User.txt";
      
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
            using (var str = new StreamWriter(FilePath, true))
            {
                str.WriteLine(user.ToString());
            };
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



        public void RefreshUserFile()
        {
            using (var strm = new StreamWriter(FilePath, false))
            {
                foreach (var item in ContextClass.users)
                {
                    strm.WriteLine(item.ToString());
                }
            }
        }

     
    }
}