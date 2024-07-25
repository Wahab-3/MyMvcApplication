using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RealEstate_Mvc_.Dtos
{
    public class CategoryRequestModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Email { get; set; } = default!;

    }
    public class CategoryResponseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<PropertyResponseModel> properties { get; set; } = new List<PropertyResponseModel>();

    }
}
