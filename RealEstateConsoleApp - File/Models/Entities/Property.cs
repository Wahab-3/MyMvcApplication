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

        // public Property(int id, int cartegoryId, string location, double price, bool isAvailable, string description, string ownerstagnumber, string userEmail, string cartegoryName, TypeOfLeases typeOfLeases) : base(id)
        // {
        //     Id = id;
        //     CartegoryId = cartegoryId;
        //     Location = location;
        //     Price = price;
        //     IsAvailable = isAvailable;
        //     Description = description;
        //     OwnersTagNumber = ownerstagnumber;
        //     UserEmail = userEmail;
        //     CartegoryName = cartegoryName;
        //     TypeOfLeases = typeOfLeases;
        // }

        public string ToString()
        {
            return $"{Id}\t{CartegoryId}\t{Location}\t{Price}\t{IsAvailable}\t{Description}\t{OwnersTagNumber}\t{UserEmail}\t{CartegoryName}\t{TypeOfLeases}";

        }


        public static Property ToObject(string a)
        {
            var data = a.Split('\t');
            Property property = new Property
            {
                Id = int.Parse(data[0]),
                CartegoryId = int.Parse(data[1]),
                Location = data[2],
                Price = double.Parse(data[3]),
                IsAvailable = bool.Parse(data[4]),
                Description = data[5],
                OwnersTagNumber = data[6],
                UserEmail = data[7],
                CartegoryName = data[8],
                TypeOfLeases = (TypeOfLeases)Enum.Parse(typeof(TypeOfLeases), data[9]),
            };
            return property;
        }
    }
}