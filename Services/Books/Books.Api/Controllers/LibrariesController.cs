using Books.Data.Models.Libraries;
using Books.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private ILibraryService _libraryService;

        public LibrariesController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LibraryDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LibraryDto>> Get(string id)
        {
            var librariesWithBooks = await _libraryService.GetAllForUser(id);
            if (librariesWithBooks == null)
            {
                return NotFound();
            }
            return Ok(librariesWithBooks);
        }
    }
}
