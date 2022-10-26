using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Users.AuthenticationApi.Exceptions;
using Users.AuthenticationApi.Models;

namespace Users.AuthenticationApi.CQRS.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }

    }

    public class GetUserQueryHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IMongoCollection<User> _usersCollection;
        public GetUserQueryHandler(IOptions<MongoDbConnectionSettings> dbSettings)
        {
            var mongoClient = new MongoClient(
                dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<User>(
                dbSettings.Value.CollectionName);
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userName = await _usersCollection.Find(u => u.UserName == request.UserName).FirstOrDefaultAsync();
            if (userName == null) throw new UserNotFoundException();
            if(!userName.IsPasswordOk(request.Password)) throw new PasswordIncorrectException();

            return "logged!";
        }

    }

}
