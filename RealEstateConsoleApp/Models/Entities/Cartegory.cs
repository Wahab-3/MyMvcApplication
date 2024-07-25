namespace RealEstateConsoleApp.Models
{
    public class Cartegory  : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get;set;}


        public Cartegory(int id,string name,string description):base(id)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}