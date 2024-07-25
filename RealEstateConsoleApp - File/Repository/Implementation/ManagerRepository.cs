using RealEstateConsoleApp.Models;
using RealEstateConsoleApp___File;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class ManagerRepository : IManagerRepository
    {
        string FilePath = Path.Combine(FileContext.FilePath, "Manager.txt");
      

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
            using (var str = new StreamWriter(FilePath, true))
            {
                str.WriteLine(manager.ToString());
            };
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

        public void RefreshManagerFile()
        {
            using (var strm = new StreamWriter(FilePath, false))
            {
                foreach (var item in ContextClass.managers)
                {
                    strm.WriteLine(item.ToString());
                }
            }

        }


    
    }
}