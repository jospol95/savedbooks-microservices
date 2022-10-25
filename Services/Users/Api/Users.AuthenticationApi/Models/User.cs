using BCrypt;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Users.AuthenticationApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PasswordHash{ get; set; }

        public bool IsPasswordOk(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }

        public void EncryptPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
