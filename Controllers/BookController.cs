using BookLibraryAPI.DTOs.Books;
using BookLibraryAPI.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<BookReadDto>> GetBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult GetBook(int id) 
        {
            var book = _bookService.GetBook(id);
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook(BookCreateDto bookDto)
        {
            var created = _bookService.AddBook(bookDto);
            return CreatedAtAction(nameof(GetBook), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookUpdateDto bookDto) 
        {    
            _bookService.UpdateBook(id, bookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) 
        {
            _bookService.DeleteBook(id);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteBooks()
        {
            _bookService.DeleteBooks();
            return NoContent();
        }
    }
}
