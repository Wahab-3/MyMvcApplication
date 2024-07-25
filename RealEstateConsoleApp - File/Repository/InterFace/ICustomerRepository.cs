using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Repository
{
    public interface ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer);
        public Customer GetCustomerByEmail(string Email);
        public Customer GetCustomerById(int id);
        public List<Customer> GetAllCustomer();
        public void RefreshCustomerFile();


    }
}