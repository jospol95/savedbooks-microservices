using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Books.Data.Models
{
    public abstract class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string UserId { get; set; }

        public Book()
        {

        }

        public string GetTitle()
        {
            return this.Title;
        }
    }
}
