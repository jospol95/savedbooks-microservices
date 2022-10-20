using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Search.Api.Models;
using System.Text.Json;

namespace Search.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        //Wrapper for Google Books Api search, so we can retrieve books based on name search criteria.

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public SearchController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
                

        [HttpGet]
        [Route("/books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<BookResponseLight>>> Search(string? bookName, int? maxResults)
        {
            if (bookName == null) return NotFound();
            maxResults = maxResults ?? 10;

            var httpClient = _httpClientFactory.CreateClient("GoogleBooksApi");
            var sanitizedBookName = bookName.Replace(" ", "%20");
            string querySearch = $"volumes?q=intitle:{sanitizedBookName}&projection=lite&printType=books&maxResults={maxResults}";
            var httpResponseMessage = await httpClient.GetAsync(querySearch);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();
                var googleBooksReponseArray = await JsonSerializer.DeserializeAsync
                    <GoogleBookResponse>(contentStream);
                var mappedBooks = new List<BookResponseLight>();

                if (googleBooksReponseArray.TotalItems < 1) return Ok();

                foreach(GoogleBookItem googleBookResponseItem in googleBooksReponseArray.Items)
                {
                    var mappedBook = _mapper.Map<BookResponseLight>(googleBookResponseItem);
                    mappedBooks.Add(mappedBook);
                }   
                var booksWithoutDuplicateTitleAndAuthor = ReduceDuplicates(mappedBooks);
                return Ok(booksWithoutDuplicateTitleAndAuthor);
            }

            return NotFound();
        }

        private IList<BookResponseLight> ReduceDuplicates(IList<BookResponseLight> books)
        {
            var consolidatedList =
                from book in books
                group book by new
                {
                    book.Title,
                    book.Author
                } into grouped
                select new BookResponseLight()
                {
                    Title = grouped.First().Title,
                    Description = grouped.First().Description,
                    Author = grouped.First().Author,
                };

            return consolidatedList.ToList();
        }
    }
}
