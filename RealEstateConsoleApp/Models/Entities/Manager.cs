namespace RealEstateConsoleApp.Models
{
    public class Manager  : BaseEntity
    {
        public string UserEmail { get; set;}

        public Manager(int id,string userEmail) : base(id)
        {
            Id = id;
            UserEmail = userEmail;
        }
    }
}