namespace RealEstateConsoleApp.Models
{
    public class Manager : BaseEntity
    {
        public string UserEmail { get; set; }

        // public Manager(int id, string userEmail) : base(id)
        // {
        //     Id = id;
        //     UserEmail = userEmail;
        // }
        public string ToString()
        {
            return $"{Id}\t{UserEmail}";

        }


        public static Manager ToObject(string a)
        {
            var data = a.Split('\t');
            Manager manager = new Manager{Id = int.Parse(data[0]),UserEmail = data[1]};
            return manager;
        }

    }
}