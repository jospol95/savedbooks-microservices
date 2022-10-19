using Books.Data.Models.LoanedBook;
using Books.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private ILoanedBookService _bookService;

        // GET: api/<BooksController>
        public BooksController(ILoanedBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("/user/{userId:string}")]
        [ProducesResponseType(typeof(IEnumerable<LoanedBook>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<LoanedBook>>> GetAllForUser(string userId)
        {
            var books = await _bookService.GetAllForUser(userId);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        // GET api/<BooksController>
        [HttpGet]
        [ProducesResponseType(typeof(LoanedBook), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<LoanedBook>>> GetAll()
        {
            var book = await _bookService.Get();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id:string}")]
        [ProducesResponseType(typeof(LoanedBook), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoanedBook>> Get(string id)
        {
            var book = await _bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post(LoanedBook newBook)
        {
            await _bookService.Create(newBook);
            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }
    }
}
