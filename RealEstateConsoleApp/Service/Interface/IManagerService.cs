using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Service.Interface
{
    public interface IManagerService
    {
        public void CreateManager(string UserEmail);
        public Manager GetManagerByEmail(string Email);
        public Manager GetManagerById(int id);
        public void GetAllManager();
        public void DeleteManager(string email);
    }
}