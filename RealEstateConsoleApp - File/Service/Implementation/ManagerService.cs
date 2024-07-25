
using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository;
using RealEstateConsoleApp.Repository.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Service.Implementation
{
    public class ManagerService : IManagerService
    {
        IManagerRepository managerRepository = new ManagerRepository();
        IUserService userService = new UserService();

        public void CreateManager(string UserEmail)
        {
            int count = ContextClass.managers.Count == 0 ? 1 : ContextClass.managers.Count + 1;
            var newManager = new Manager { Id = count, UserEmail = UserEmail };
            managerRepository.CreateManager(newManager);
        }

        public void DeleteManager(string email)
        {
            var getByEmail = managerRepository.GetManagerByEmail(email);
            if (getByEmail == null)
            {
                System.Console.WriteLine("manager does not exist");
            }
            ContextClass.managers.Remove(getByEmail);
            managerRepository.RefreshManagerFile();

        }

        public void GetAllManager()
        {
            var getAll = managerRepository.GetAllManager();
            if (getAll == null)
            {
                System.Console.WriteLine("no manager added yet");
            }
            else
            {
                foreach (var item in getAll)
                {
                    var user = userService.GetUserByEmail(item.UserEmail);
                    System.Console.WriteLine($"ManagersName : {user.LastName}  {user.FirstName} ManagersEmail :{item.UserEmail}  ");
                }
            }

        }

        public Manager GetManagerByEmail(string Email)
        {
            var getManagerByEmail = managerRepository.GetManagerByEmail(Email);
            if (getManagerByEmail == null)
            {
                System.Console.WriteLine("manager does not exist");
                return null;
            }
            return getManagerByEmail;
        }

        public Manager GetManagerById(int id)
        {
            var getManagerByid = managerRepository.GetManagerById(id);
            if (getManagerByid == null)
            {
                System.Console.WriteLine("manager does not exist");
                return null;
            }
            return getManagerByid;
        }


        public void UpdateManager(string OldEmail, string Email)
        {
            var getManagerByEmail = managerRepository.GetManagerByEmail(OldEmail);
            if (getManagerByEmail == null)
            {
                System.Console.WriteLine(" manager does not exist");

            }
            getManagerByEmail.UserEmail = Email;
            managerRepository.RefreshManagerFile();
        }
    }
}