
namespace RealEstateConsoleApp.Models
{
  public class User : BaseEntity
    {
        public string Email {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public long PhoneNumber {get; set;}
        public int Age {get; set;}
        public string Address {get; set;}
        public Gender Gender{get;set;}
        public string RoleName {get; set;}
        public string Password {get; set;}
        public double Wallet {get; set;}=0;
        public User( int id,string email,string firstName,string lastName, long phoneNumber,int age, string address,Gender gender,string roleName , string password,double wallet) : base(id)
        {
            Id = id;
            Email = email;
            Gender = gender;
            FirstName = firstName;
            LastName =lastName;
            PhoneNumber = phoneNumber;
            Age =age;
            Address = address;
            RoleName = roleName;
            Password = password;
            Wallet = wallet;
        }


        




    }
}