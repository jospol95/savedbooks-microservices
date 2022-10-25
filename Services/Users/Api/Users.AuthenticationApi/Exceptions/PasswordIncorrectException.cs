namespace Users.AuthenticationApi.Exceptions
{
    public class PasswordIncorrectException: Exception
    {
        public PasswordIncorrectException(): base("The password is incorrect")
        {

        }
    }
}
