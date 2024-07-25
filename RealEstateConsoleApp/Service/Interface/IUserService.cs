using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Service.Interface
{
    public interface IUserService
    {
        public void CreateUser(string Email, string FirstName, string LastName, long PhoneNumber, int Age, string Address, Gender Gender, string Password,string RoleName);
        public User GetUserByEmail(string Email);
        public User GetUserById(int id);
        public void GetAllUser();
        public User GetUserByEmailAndPassword(string Email, string Password);
        public User GetUserByRole(string roleName);
        public void UpdateUser(string OldEmail, string Email, string FirstName, string LastName, int PhoneNumber, int Age, string Address, Gender Gender, string Password, double Wallet);
        public void DeleteUser(string Email);
    }
}