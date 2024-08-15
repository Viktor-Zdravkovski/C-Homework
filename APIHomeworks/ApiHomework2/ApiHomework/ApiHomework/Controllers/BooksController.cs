using ApiHomework.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{index}")]
        public ActionResult<Book> GetBookByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index cant be negative number, try again");
                }

                if (index > StaticDb.Books.Count)
                {
                    return BadRequest("The index is over book's count");
                }

                return Ok(StaticDb.Books[index]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("multipleQueryParams")]
        public ActionResult<List<Book>> GetBookByNames([FromQuery] string? author, [FromQuery] string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return Ok(StaticDb.Books);
                }

                if (string.IsNullOrEmpty(author))
                {
                    List<Book> filteredAuthors = StaticDb.Books.Where(x => x.Author == author).ToList();
                    return Ok(filteredAuthors);
                }

                if (string.IsNullOrEmpty(title))
                {
                    List<Book> filteredTitles = StaticDb.Books.Where(x => x.Title == title).ToList();
                    return Ok(filteredTitles);
                }

                List<Book> filteredBooks = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower()) && x.Title.ToLower().Contains(title.ToLower())).ToList();
                return Ok(filteredBooks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddNewBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Author cant be empty");
                }

                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Title cant be empty");
                }

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "The book has been successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("AddingTitles")]
        public ActionResult<List<string>> AddListOfBooks([FromBody] List<Book> books)
        {
            try
            {
                List<string> bookTitles = new List<string>();
                foreach (var book in books)
                {
                    if (string.IsNullOrEmpty(book.Author))
                    {
                        //return BadRequest("Author cant be null/empty"); 
                        return StatusCode(StatusCodes.Status400BadRequest, "The author field cannot be empty");
                    }

                    if (string.IsNullOrEmpty(book.Title))
                    {
                        //return BadRequest("Title cant be null/empty");
                        return StatusCode(StatusCodes.Status400BadRequest, "The title field cannot be empty");
                    }

                    bookTitles.Add(book.Title);
                }
                return bookTitles;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
