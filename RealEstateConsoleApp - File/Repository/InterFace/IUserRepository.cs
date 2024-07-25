using RealEstateConsoleApp.Models;


namespace RealEstateConsoleApp.Repository
{
    public interface IUserRepository
    {
        public User CreateUser(User user);
        public User GetUserByEmail(string Email);
        public User GetUserById(int id);
        public List<User> GetAllUser();
        public User GetUserByEmailAndPassword(string Email, string Password);
        public User GetUserByRole(string roleName);
        public void RefreshUserFile();



    }
}