using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateMvc.Models.Enum;

namespace RealEstate_Mvc_.Dtos
{
    public class OwnerRequestModel
    {

        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public long PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }
        public string ConfirmPassword { get; set; }

        public IFormFile? ProfilePicture { get; set; }
    }
    public class OwnerResponseModel
    {
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public long PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; } = default!;
        public Gender Gender { get; set; }
        public bool IsAvailable { get; set; }
        public IFormFile? ProfilePicture { get; set; }

        public string StaffNumber { get; set; } = default!;
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
