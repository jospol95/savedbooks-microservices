using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Search.Api.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Search.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        //Wrapper for Google Books Api search, so we can retrieve books based on name search criteria.

        private readonly IHttpClientFactory _httpClientFactory;
        public SearchController(IHttpClientFactory httpClientFactory) =>
                _httpClientFactory = httpClientFactory;

        [HttpGet]
        [Route("/books")]
        public async Task Search(string bookName, int maxResults)
        {
            var httpClient = _httpClientFactory.CreateClient("GoogleBooksApi");
            var sanitizedBookName = bookName.Replace(" ", "%20");
            string querySearch = $"volumes?q=intitle:{sanitizedBookName}&projection=lite&printType=books&maxResults={maxResults}";
            var httpResponseMessage = await httpClient.GetAsync(querySearch);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();
                var googleBooks = await JsonSerializer.DeserializeAsync
                    <GoogleBookResponse>(contentStream);
            }
        }
    }
}
