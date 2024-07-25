namespace RealEstateConsoleApp.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // public Role(int id, string name, string description) : base(id)
        // {
        //     Id = id;
        //     Name = name;
        //     Description = description;
        // }


        public string ToString()
        {
            return $"{Id}\t{Name}\t{Description}";
        }

        public static Role ToObject(string a)
        {
            var data = a.Split('\t');
            Role role = new Role {Id=int.Parse(data[0]),Name=data[1],Description=data[2] };

            return role;
        }

    }
}