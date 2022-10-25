namespace Users.AuthenticationApi.Exceptions
{
    public class UserAlreadyExistsException: Exception
    {
        public UserAlreadyExistsException(): base("The user already exists")
        {

        }

    }
}
