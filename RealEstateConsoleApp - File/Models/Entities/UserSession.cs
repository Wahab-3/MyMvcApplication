namespace RealEstateConsoleApp.Models.Entities
{
    public class UserSession
    {
        public static string LoggedInUserEmail { get; private set; }

        public static void SetLoggedInUserEmail(string email)
        {
            LoggedInUserEmail = email;
        }

    }
}