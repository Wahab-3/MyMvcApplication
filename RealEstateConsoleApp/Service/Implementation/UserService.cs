


using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository;
using RealEstateConsoleApp.Repository.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Service.Implementation
{
    public class UserService : IUserService
    {
        IUserRepository userRepository = new UserRepository();
        
        public void CreateUser(string Email, string FirstName, string LastName, long PhoneNumber, int Age, string Address, Gender gender, string Password, string RoleName)
        {
            var newUser = new User(ContextClass.users.Count + 1, Email, FirstName, LastName, PhoneNumber, Age, Address, gender, RoleName, Password, 0);
            userRepository.CreateUser(newUser);
        }

     

        public void DeleteUser(string Email)
        {
            var getUserByEmail = userRepository.GetUserByEmail(Email);
            if (getUserByEmail == null)
            {
                System.Console.WriteLine("User does not exist");
            }
            ContextClass.users.Remove(getUserByEmail);
        }

        public void GetAllUser()
        {
            var getAll = userRepository.GetAllUser();
            if (getAll == null)
            {
                System.Console.WriteLine(" no user added yet");
            }
            else
            {
                foreach (var item in getAll)
                {
                    System.Console.WriteLine($"UserName : {item.LastName}  {item.FirstName} UserEmail :{item.Email}  ");
                }
            }
        }

        public User GetUserByEmail(string Email)
        {
            var getUserByEmail = userRepository.GetUserByEmail(Email);
            if (getUserByEmail == null)
            {
                System.Console.WriteLine("User does not exist");
                return null;
            }
            return getUserByEmail;
        }

        public User GetUserByEmailAndPassword(string Email, string Password)
        {
            var getUserByEmailAndPassword = userRepository.GetUserByEmailAndPassword(Email, Password);
            if (getUserByEmailAndPassword == null)
            {
                System.Console.WriteLine("User does not exist");
                return null;
            }
            return getUserByEmailAndPassword;
        }

        public User GetUserById(int id)
        {
            var getUserById = userRepository.GetUserById(id);
            if (getUserById == null)
            {
                System.Console.WriteLine("User does not exist");
                return null;
            }
            return getUserById;
        }

        public User GetUserByRole(string roleName)
        {
            var getUserByRole = userRepository.GetUserByRole(roleName);
            if (getUserByRole == null)
            {
                System.Console.WriteLine("User does not exist");
                return null;
            }
            return getUserByRole;
        }

        public void UpdateUser(string OldEmail, string Email, string FirstName, string LastName, int PhoneNumber, int Age, string Address, Gender Gender, string Password, double Wallet)
        {
            var getUserByEmail = userRepository.GetUserByEmail(OldEmail);
            if (getUserByEmail == null)
            {
                System.Console.WriteLine(" User does not exist");

            }
            getUserByEmail.Email = Email;
            getUserByEmail.FirstName = FirstName;
            getUserByEmail.LastName = LastName;
            getUserByEmail.PhoneNumber = PhoneNumber;
            getUserByEmail.Age = Age;
            getUserByEmail.Address = Address;
            getUserByEmail.Gender = Gender;
            getUserByEmail.Password = Password;
            getUserByEmail.Wallet = Wallet;
        }

      
    }
}