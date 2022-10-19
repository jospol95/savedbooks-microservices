using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Data
{
    public class MongoDbSettings
    {        
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
