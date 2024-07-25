using RealEstateConsoleApp.Models;
using RealEstateConsoleApp___File;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        string FilePath = Path.Combine(FileContext.FilePath, "Customer.txt");

      
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
            using (var str = new StreamWriter(FilePath, true))
            {
                str.WriteLine(customer.ToString());
            };
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



        public void RefreshCustomerFile()
        {
            using (var strm = new StreamWriter(FilePath, false))
            {
                foreach (var item in ContextClass.customers)
                {
                    strm.WriteLine(item.ToString());
                }
            }

        }


      
    }
}