namespace RealEstateConsoleApp.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set;}
        public string Description { get; set;}

        public Role(int id, string name, string description) : base(id)
        {
            Id = id;
            Name = name;
            Description = description;
        }

    }
}