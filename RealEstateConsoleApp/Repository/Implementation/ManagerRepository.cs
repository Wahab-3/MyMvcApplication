using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class ManagerRepository : IManagerRepository
    {
        public Manager CreateManager(Manager manager)
        {
            var context = ContextClass.managers;
            foreach (var item in context)
            {
                if (item.UserEmail == manager.UserEmail)
                {
                    return null;
                }
            }
            context.Add(manager);
            return manager;
        }

        public List<Manager> GetAllManager()
        {
            var context = ContextClass.managers;
            return context;
        }

        public Manager GetManagerByEmail(string Email)
        {
            var context = ContextClass.managers;
            foreach (var item in context)
            {
                if (item.UserEmail == Email)
                {
                    return item;
                }
            }
            return null;
        }

        public Manager GetManagerById(int id)
        {
            var context = ContextClass.managers;
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