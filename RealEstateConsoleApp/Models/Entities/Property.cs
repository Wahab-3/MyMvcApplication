namespace RealEstateConsoleApp.Models
{
    public class Property : BaseEntity
    {
        public string UserEmail { get; set; }
        public int CartegoryId { get; set; }
        public string CartegoryName { get; set; }
        public string Location { get; set; }
        public TypeOfLeases TypeOfLeases { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Description { get; set; }
        public string OwnersTagNumber { get; set; }

        public Property(int id, int cartegoryId, string location, double price, bool isAvailable, string description, string ownerstagnumber, string userEmail,string cartegoryName,TypeOfLeases typeOfLeases ) : base(id)
        {
            Id = id;
            CartegoryId = cartegoryId;
            Location = location;
            Price = price;
            IsAvailable = isAvailable;
            Description = description;
            OwnersTagNumber = ownerstagnumber;
            UserEmail = userEmail;
            CartegoryName = cartegoryName;
            TypeOfLeases=typeOfLeases;
        }
    }
}