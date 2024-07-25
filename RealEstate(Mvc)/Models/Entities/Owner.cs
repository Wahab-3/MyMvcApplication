namespace RealEstateMvc.Models.Entities
{
    public class Owner 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string StaffNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
       public  List<Property> Properties { get; set; } = new List<Property>();
        public string? DeletedBy { get; set; }
        public DateTime DateDeleted { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime? DateCrated { get; set; }

        public string? ProfilePicturePath { get; set; }


    }
}