using BookLibraryAPI.DTOs;
using BookLibraryAPI.Services;
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
        public async Task<ActionResult> AddBook(BookCreateDto bookDto)
        {
            var created = await _bookService.AddBook(bookDto);
            return CreatedAtAction(nameof(GetBook), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookUpdateDto bookDto) 
        {    
            await _bookService.UpdateBook(id, bookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id) 
        {
            await _bookService.DeleteBook(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooks()
        {
            await _bookService.DeleteBooks();
            return NoContent(); 
        }
    }
}
