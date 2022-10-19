using Libraries.Data.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Books.Data.Models
{
    public abstract class Book : IEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
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
