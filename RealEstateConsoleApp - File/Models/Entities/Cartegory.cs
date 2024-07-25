namespace RealEstateConsoleApp.Models
{
    public class Cartegory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }


        // public Cartegory(int id, string name, string description) : base(id)
        // {
        //     Id = id;
        //     Name = name;
        //     Description = description;
        // }


        public string ToString()
        {
            return $"{Id}\t{Name}\t{Description}";
        }


        public static Cartegory ToObject(string a)
        {
            var data = a.Split('\t');
            Cartegory cartegory = new Cartegory {Id=int.Parse(data[0]),Name = data[1],Description = data[2]};
            return cartegory;
        }
    }
}