using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EventDrivenBookstoreAPI.Models;
using EventDrivenBookstoreAPI.Interface;
using EventDrivenBookstoreAPI.Implementation;

namespace EventDrivenBookstoreAPI.Controllers
{
    // Define the route and controller attributes for the Books API
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService; // Service for book-related operations

        // Constructor injection for the book service
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // HTTP GET endpoint to retrieve a book by its ID
        [HttpGet("{bookId}")]
        public async Task<ActionResult<Book>> GetBook(string bookId)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(bookId);
                if (book != null)
                {
                    return Ok(book); // Return the book details if found
                }
                return NotFound(); // Return 404 if the book is not found
            }
            catch (Exception ex)
            {
                // Log the exception and return a 400 Bad Request with the error message
                return BadRequest(ex.Message);
            }
        }

        // HTTP POST endpoint to create a new book
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            try
            {
                var response = await _bookService.CreateBookAsync(book);
                if (response != null)
                {
                    return Ok(response); // Return the created book details
                }
                return BadRequest(); // Return 400 if the book creation failed
            }
            catch (Exception ex)
            {
                // Log the exception and return a 400 Bad Request with the error message
                return BadRequest(ex.Message);
            }
        }
    }
}

