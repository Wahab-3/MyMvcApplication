

using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository;
using RealEstateConsoleApp.Repository.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Service.Implementation
{
    public class OwnerService : IOwnerService
    {

        IOwnerRepository ownerRepository = new OwnerRepository();
        IUserService userService = new UserService();
        public void CreateOwner(string UserEmail)
        {
            int count = ContextClass.owners.Count == 0 ? 1 : ContextClass.owners.Count + 1;
            var newOwner = new Owner { Id = count, UserEmail = UserEmail, TagNumber = $"Owner/wertt//f/00{count}" };
            ownerRepository.CreateOwner(newOwner);
        }

        public void DeleteOwner(string email)
        {
            var getByEmail = ownerRepository.GetOwnerByEmail(email);
            if (getByEmail == null)
            {
                System.Console.WriteLine("owner does not exist");
            }
            ContextClass.owners.Remove(getByEmail);
            ownerRepository.RefreshOwnerFile();

        }

        public void GetAllOwner()
        {
            var getAll = ownerRepository.GetAllOwner();
            if (getAll == null)
            {
                System.Console.WriteLine("no owner added yet");
            }
            else
            {
                foreach (var item in getAll)
                {
                    var user = userService.GetUserByEmail(item.UserEmail);
                    System.Console.WriteLine($"OwnersName : {user.LastName}  {user.FirstName} COwnersEmail :{user.Email}  ");
                }
            }
        }

        public Owner GetOwnerByEmail(string Email)
        {
            var getOwnerByEmail = ownerRepository.GetOwnerByEmail(Email);
            if (getOwnerByEmail == null)
            {
                System.Console.WriteLine("Owner does not exist");
                return null;
            }
            return getOwnerByEmail;
        }

        public Owner GetOwnerById(int id)
        {
            var getOwnerById = ownerRepository.GetOwnerById(id);
            if (getOwnerById == null)
            {
                System.Console.WriteLine("Owner does not exist");
                return null;
            }
            return getOwnerById;
        }


        public void UpdateOwner(string OldEmail, string Email)
        {
            var getOwnerByEmail = ownerRepository.GetOwnerByEmail(OldEmail);
            if (getOwnerByEmail == null)
            {
                System.Console.WriteLine(" Owner does not exist");

            }
            getOwnerByEmail.UserEmail = Email;
            ownerRepository.RefreshOwnerFile();
        }
    }
}