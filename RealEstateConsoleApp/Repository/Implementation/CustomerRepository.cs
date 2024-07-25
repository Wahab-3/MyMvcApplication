using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer)
        {
            var context = ContextClass.customers;
            foreach (var item in context)
            {
                if (item.UserEmail == customer.UserEmail)
                {
                    return null;
                }
            }
            context.Add(customer);
            return customer;
        }

        public List<Customer> GetAllCustomer()
        {
            var context = ContextClass.customers;
            return context;
        }

        public Customer GetCustomerByEmail(string Email)
        {
            var context = ContextClass.customers;
            foreach (var item in context)
            {
                if (item.UserEmail == Email)
                {
                    return item;
                }
            }
            return null;
        }

        public Customer GetCustomerById(int id)
        {
            var context = ContextClass.customers;
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