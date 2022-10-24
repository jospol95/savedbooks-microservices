using Books.Data;
using Books.Data.Models.LoanedBook;
using Books.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Infrastructure.Services
{
    public class LoanedBookService : ILoanedBookService
    {
        private readonly IMongoCollection<LoanedBook> _booksCollection;
        public LoanedBookService(
        IOptions<MongoDbSettings> savedBookDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                savedBookDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                savedBookDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<LoanedBook>(
                MongoDbCollectionNames.LoanedBooksCollection);
        }

        public async Task<LoanedBook> Create(LoanedBook newBook)
        {
            await _booksCollection.InsertOneAsync(newBook);
            return newBook;
        }

        public async Task<LoanedBook> Get(string id)
        {
            var book = await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            book.CalculateDue(DateTime.Today);
            return book;
        }

        public async Task<List<LoanedBook>> Get()
        {
            var books = await _booksCollection.Find((b) => true).ToListAsync();
            books.ForEach((book) => book.CalculateDue(DateTime.Now));
            return books;
        }

        public async Task<List<LoanedBook>> GetAllForUser(string userId)
        {
            return await _booksCollection.Find(x => x.UserId == userId).ToListAsync();
        }

        public async Task UpdateDueDaysForBooks(DateTime dateTimeToCompare)
        {
            //var books = await _booksCollection.Find(_ => true).ToListAsync();
            //foreach (var book in books)
            //{
            //    var inDue = book.CheckIfInDue(dateTimeToCompare);
            //    if (inDue)
            //    {
            //        book.PastDueOneDay();
            //        await _booksCollection.ReplaceOneAsync((bookDb) => bookDb.Id == book.Id, book);
            //    }
            //}
        }
    }
}
