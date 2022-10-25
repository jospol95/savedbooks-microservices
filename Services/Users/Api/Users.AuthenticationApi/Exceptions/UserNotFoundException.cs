namespace Users.AuthenticationApi.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(): base("The username was not found")
        {
            
        }
    }
}
