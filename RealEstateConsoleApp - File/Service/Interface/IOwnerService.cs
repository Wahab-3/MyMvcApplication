using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Service.Interface
{
    public interface IOwnerService
    {
        public void CreateOwner(string UserEmail);
        public Owner GetOwnerByEmail(string Email);
        public Owner GetOwnerById(int id);
        public void GetAllOwner();
        public void DeleteOwner(string email);
        public void UpdateOwner(string OldEmail, string Email);

    }
}