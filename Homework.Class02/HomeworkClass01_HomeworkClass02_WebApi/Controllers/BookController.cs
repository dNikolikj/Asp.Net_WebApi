using HomeworkClass01.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeworkClass01.DTOs.BookDtos;
using HomeworkClass01.Domain.Models;

namespace HomeworkClass01_HomeworkClass02_WebApi.Controllers
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
        public ActionResult<List<BookDummyDto>> GetAllBooks()
        {
            try
            {
                List<BookDummyDto> bookDummyDto = _bookService.GetAllBooks();
                return Ok(bookDummyDto);
                

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please contacto the administrator!");
            }
        }

        [HttpGet("querryNotation")] 
        public ActionResult<BookDummyDto> GetBookById(int? id)
        {
            if(id == null)
            {
                return NotFound("The book you were looking for does not exist!");
            }
            try
            {
                BookDummyDto bookDummyDto = _bookService.GetBookById(id.Value);
                return Ok(bookDummyDto);

            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please contacto the administrator!");
            }
        }

        [HttpGet("filterByAuthorAndTitle")]

        public ActionResult<List<Book>> FilterBooksByAuthorAndTitle(string? author, string? title)
        {
            try
            {
                List<Book> filteredBooks = _bookService.Filter(author, title);
                return Ok(filteredBooks);
            } 
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please contacto the administrator!");
            }


        }

        [HttpGet("addBook")]
        public IActionResult AddBookToTheLibrary([FromBody] BookDummyDto bookDummyDto)
        {
            try
            {
                _bookService.CreateBook(bookDummyDto);
                return StatusCode(StatusCodes.Status201Created, "New book was added in the library!");
            
            } 
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please contacto the administrator!");
            }
        }

        [HttpGet("listOfTitles")]

        public ActionResult<BooksTitleDto> GetAllBookTitles ()
        {
            try
            {
                BooksTitleDto bookTitlesDto = _bookService.GetAllTitles();
                return Ok(bookTitlesDto);


            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please contacto the administrator!");
            }
        }
    }
}
