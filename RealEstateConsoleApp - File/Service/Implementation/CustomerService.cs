
using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository;
using RealEstateConsoleApp.Repository.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        IUserService userService = new UserService();
        public void CreateCustomer(string UserEmail)
        {
            int count = ContextClass.customers.Count == 0 ? 1 : ContextClass.customers.Count + 1;
            var newCustomer = new Customer { Id = count, UserEmail = UserEmail, TagNumber = $"aaffSS3400{count}" };
            customerRepository.CreateCustomer(newCustomer);
        }

        public void DeleteCustomer(string email)
        {
            var delete = customerRepository.GetCustomerByEmail(email);
            if (delete == null)
            {
                System.Console.WriteLine("customer does not exist");
            }
            ContextClass.customers.Remove(delete);
            customerRepository.RefreshCustomerFile();

        }

        public void GetAllCustomer()
        {
            var getAll = customerRepository.GetAllCustomer();
            if (getAll == null)
            {
                System.Console.WriteLine("no customer added yet");
            }
            else
            {
                foreach (var item in getAll)
                {
                    var user = userService.GetUserByEmail(item.UserEmail);
                    System.Console.WriteLine($"CustomersName : {user.LastName}  {user.FirstName} CustomersEmail :{item.UserEmail}  ");
                }
            }

        }

        public Customer GetCustomerByEmail(string Email)
        {
            var getCustomerByEmail = customerRepository.GetCustomerByEmail(Email);
            if (getCustomerByEmail == null)
            {
                System.Console.WriteLine("customer does not exist");
                return null;
            }
            return getCustomerByEmail;
        }

        public Customer GetCustomerById(int id)
        {
            var getCustomerById = customerRepository.GetCustomerById(id);
            if (getCustomerById == null)
            {
                System.Console.WriteLine("customer does not exist");
                return null;
            }
            return getCustomerById;
        }


        public void UpdateCustomer(string OldEmail, string Email)
        {
            var getCustomerByEmail = customerRepository.GetCustomerByEmail(OldEmail);
            if (getCustomerByEmail == null)
            {
                System.Console.WriteLine(" customer does not exist");

            }
            getCustomerByEmail.UserEmail = Email;
            customerRepository.RefreshCustomerFile();

        }
    }
}