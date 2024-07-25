namespace RealEstateConsoleApp.Models
{
    public class Owner  : BaseEntity
    {
        public string UserEmail { get; set;}
        public string TagNumber { get; set;}

        public Owner(int id,string userEmail,string tagNumber) : base(id)
        {
            Id = id;
            UserEmail = userEmail;
            TagNumber = tagNumber;
        
        }
    }
}