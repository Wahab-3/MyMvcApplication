using RealEstate_Mvc_.Models.Entities;

namespace RealEstate_Mvc_.Dtos
{
    public class RoleRequestModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? Email { get; set; }
    }
    public class RoleResponseModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
