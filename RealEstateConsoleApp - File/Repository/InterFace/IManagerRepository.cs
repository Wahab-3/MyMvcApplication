using RealEstateConsoleApp.Models;


namespace RealEstateConsoleApp.Repository
{
    public interface IManagerRepository
    {
        public Manager CreateManager(Manager manager);
        public Manager GetManagerByEmail(string Email);
        public Manager GetManagerById(int id);
        public List<Manager> GetAllManager();
        public void RefreshManagerFile();

    }
}