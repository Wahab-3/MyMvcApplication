
using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Repository
{
    public interface IOwnerRepository
    {
        public Owner CreateOwner(Owner owner);
        public Owner GetOwnerByEmail(string Email);
        public Owner GetOwnerById(int id);
        public Owner GetOwnerByTagNumber(string TagNumber);
        public List<Owner> GetAllOwner();
        public void RefreshOwnerFile();

    }
}