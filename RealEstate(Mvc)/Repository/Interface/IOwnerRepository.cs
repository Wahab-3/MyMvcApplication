using RealEstateMvc.Models.Entities;

namespace RealEstate_Mvc_.Repository.Interface
{
    public interface IOwnerRepository
    {
        bool Check(string StaffNumber);
        Owner Create(Owner Owner);
        Owner GetById(string Id);
        Owner GetByEmail(string Email);
        Owner GetByStaffNumber(string StaffNumber);
        List<Owner> GetAll();
        Owner Update(Owner Owner);


    }
}