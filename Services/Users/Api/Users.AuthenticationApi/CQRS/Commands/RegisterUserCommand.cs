using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Users.AuthenticationApi.Exceptions;
using Users.AuthenticationApi.Models;

namespace Users.AuthenticationApi.CQRS.Commands
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IMongoCollection<User> _usersCollection;
        public RegisterUserCommandHandler(IOptions<MongoDbConnectionSettings> dbSettings)
        {
            var mongoClient = new MongoClient(
                dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<User>(
                dbSettings.Value.CollectionName);
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersCollection.Find(u => u.UserName == request.UserName).FirstOrDefaultAsync();
            if (user != null) throw new UserAlreadyExistsException();

            var newUser = new User()
            {
                UserName = request.UserName,
                Name = request.Name,
            };
            newUser.EncryptPassword(request.Password);
            await _usersCollection.InsertOneAsync(newUser);
            return "created!";
        }
    }
}
