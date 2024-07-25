using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateMvc.Models.Entities;
using RealEstateMvc.Models.Enum;

namespace RealEstate_Mvc_.Dtos
{
    public class PropertyRequestModel
    {
        public string? Id { get; set; }
        public string Location { get; set; } = default!;
        public TYpeOfLeases TypeOfLeases { get; set; } = default!;
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public MultiSelectList Categories { get; set; }
        public string? CategoryId { get; set; }
        public IFormFile? ProfilePicture { get; set; }

    }
    public class PropertyResponseModel
    {
        public string Location { get; set; } = default!;
        public TYpeOfLeases TypeOfLeases { get; set; } = default!;
        public double Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public Category Category { get; set; }
        public string? OwnerId { get; set; }
        public string? OwnerEmail { get; set; }
        public IFormFile? ProfilePicture { get; set; }


    }
}
