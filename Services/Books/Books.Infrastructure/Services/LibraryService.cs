using Books.Data.Models.Libraries;
using Books.Data.Models.LoanedBook;
using Books.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Infrastructure.Services
{
    public class LibraryService: ILibraryService
    {
        private readonly ILoanedBookService _bookService;
        public LibraryService(ILoanedBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IEnumerable<LibraryDto>> GetAllForUser(string userId)
        {
            var books = await _bookService.GetAllForUser(userId);
            if(books.Count > 0)
            {
                var libraries = books.Select((b) => b.Library).ToList();
                ReduceDuplicates(ref libraries);
                var librariesDto = ConvertToDto(libraries);
                MapBooks(books, librariesDto);
                return librariesDto;
            }
            return null;
        }

        private void MapBooks(List<LoanedBook> books, List<LibraryDto> libraries)
        {
            foreach(var library in libraries)
            {
                var bookNames = books.Where((b) => b.Library.Name == library.Details.Name).Select((b) => b.Title).ToArray();
                library.BorrowedBooksName = bookNames;
                library.BorrowedBooksCount = bookNames.Length;
            }
        }

        public void ReduceDuplicates(ref List<Library> libraries)
        {
            libraries = libraries.GroupBy((l) => l.Name).Select((l) => l.First()).ToList();
        }

        public List<LibraryDto> ConvertToDto(List<Library> libraries)
        {
            var dtos = new List<LibraryDto>(libraries.Count);
            foreach(Library library in libraries)
            {
                dtos.Add(new LibraryDto()
                {
                    Details = library,
                    BorrowedBooksCount = 0,
                    BorrowedBooksName = new string[] { }
                });
            }

            return dtos;
        }
    }
}
