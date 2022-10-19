
namespace Books.Data.Models.Libraries
{
    public class LibraryDto
    {
        public Library Details { get; set; }
        public string[] BorrowedBooksName { get; set; }
        public int BorrowedBooksCount { get; set; }

    }
}
