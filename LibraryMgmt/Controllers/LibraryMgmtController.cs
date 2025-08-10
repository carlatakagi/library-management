using LibraryMgmt.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgmt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryMgmtController : ControllerBase
    {
        private readonly ILogger<LibraryMgmtController> _logger;

        public LibraryMgmtController(ILogger<LibraryMgmtController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetBooks() {
            {
                var response = new List<Book>
                {
                    new Book
                    {
                        Id = 1,
                        Title = "Twilight",
                        Author = "Stephenie Meyer",
                        PublishedDate = new DateTime(2005, 9, 27),
                        Genre = "Romance",
                        IsAvailable = true,
                        Quantity = 5,
                        Price = 10.99m
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "1984",
                        Author = "George Orwell",
                        PublishedDate = new DateTime(1949, 6, 8),
                        Genre = "Dystopian",
                        IsAvailable = true,
                        Quantity = 3,
                        Price = 8.99m
                    }
                };

                return Ok(response);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null || string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            {
                return BadRequest("Invalid book data.");
            }

            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null || id <= 0 || string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            {
                return BadRequest("Invalid book data.");
            }
            
            return Ok(book);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBook(int id)
        {
            if (id <= 0)
            {
                return NotFound("Book not found.");
            }

            return NoContent();
        }
    }
}
