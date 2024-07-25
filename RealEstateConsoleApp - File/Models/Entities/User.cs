
namespace RealEstateConsoleApp.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public double Wallet { get; set; }
        // public User(int id, string email, string firstName, string lastName, long phoneNumber, int age, string address, Gender gender, string roleName, string password, double wallet) : base(id)
        // {
        //     Id = id;
        //     Email = email;
        //     Gender = gender;
        //     FirstName = firstName;
        //     LastName = lastName;
        //     PhoneNumber = phoneNumber;
        //     Age = age;
        //     Address = address;
        //     RoleName = roleName;
        //     Password = password;
        //     Wallet = wallet;
        // }



        public string ToString()
        {
            return $"{Id}\t{Email}\t{FirstName}\t{LastName}\t{PhoneNumber}\t{Age}\t{Address}\t{Gender}\t{RoleName}\t{Password}\t{Wallet}";
        }
        public static User ToObject(string a)
        {
            var data = a.Split('\t');
            User user = new User
            {
                Id = int.Parse(data[0]),
                Email = data[1],
                FirstName = data[2],
                LastName = data[3],
                PhoneNumber = long.Parse(data[4]),
                Age = int.Parse(data[5]),
                Address = data[6],
                Gender = (Gender)Enum.Parse(typeof(Gender),data[7]),
                RoleName = data[8],
                Password = data[9],
                Wallet = double.Parse(data[10])
            };
            return user;
        }






    }
}