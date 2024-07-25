using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Service.Interface
{
    public interface ICustomerService
    {
         
       public void CreateCustomer(String UserEmail); 
       public Customer GetCustomerByEmail(string Email); 
       public Customer GetCustomerById( int id);
       public void GetAllCustomer(); 
         public void DeleteCustomer(string email); 
    }
}