using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;

namespace BookStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext _context;

        //Dependency Injection: The BookController constructor injects an
        //instance of BookDbContext to enable database access within the
        //controller.
        public BookController(BookDbContext bookDbContext)
        {
            _context = bookDbContext;
        }

        //Asynchronous Operations: All controller actions are asynchronous,
        //using async and await, to improve scalability and responsiveness
        //by not blocking the request thread.

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _context.Books.ToListAsync();

            if (books == null)
                return NotFound();

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Book book)
        {
            // check if the incoming data meets the validation rules specified
            // in the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        // [Authorize] f OAuth Authentication
        [HttpPut]
        public async Task<IActionResult> Update(int id, Book newBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Price = newBook.Price;

            await _context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpGet]
        //[Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound("Book not found");

            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIsDeleted(int id, bool isDeleted)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.IsDeleted = isDeleted;

            await _context.SaveChangesAsync();

            return Ok(book);
        }
    }
}

