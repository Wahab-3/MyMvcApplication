namespace RealEstateConsoleApp.Models
{
    public class Customer : BaseEntity
    {
        public string UserEmail { get; set; }
        public string TagNumber { get; set; }

        // public Customer(int id, string userEmail, string tagnumber) : base(id)
        // {
        //     Id = id;
        //     UserEmail = userEmail;
        //     TagNumber = tagnumber;

        // }

        public string ToString()
        {
            return $"{Id}\t{UserEmail}\t{TagNumber}";

        }

        public static Customer ToObject(string a)
        {
            var data = a.Split('\t');
            var customer = new Customer{Id =int.Parse(data[0]),UserEmail = data[1],TagNumber = data[2]};
            return customer;
        }
    }
}