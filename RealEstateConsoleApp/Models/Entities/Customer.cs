namespace RealEstateConsoleApp.Models
{
    public class Customer  : BaseEntity
    {
        public string UserEmail { get; set;}
        public string TagNumber { get; set;}

        public Customer(int id,string userEmail,string tagnumber) : base(id)
        {
            Id = id;
            UserEmail = userEmail;
            TagNumber = tagnumber;
           
        }
    }
}