namespace RealEstateConsoleApp.Models
{
    public class Owner : BaseEntity
    {
        public string UserEmail { get; set; }=default!;
        public string TagNumber { get; set; }

        // public Owner(int id, string userEmail, string tagNumber) : base(id)
        // {
        //     Id = id;
        //     UserEmail = userEmail;
        //     TagNumber = tagNumber;

        // }

        public string ToString()
        {
            return $"{Id}\t{UserEmail}\t{TagNumber}";

        }


        public static Owner ToObject(string a)
        {
            var data = a.Split('\t');
            Owner owner = new Owner{Id = int.Parse(data[0]),UserEmail = data[1], TagNumber = data[2]};
            return owner;
        }
    }
}