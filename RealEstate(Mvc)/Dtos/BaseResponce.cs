namespace RealEstate_Mvc_.Dtos
{
    public class BaseResponce<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
    }
}
