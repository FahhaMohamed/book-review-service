using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly ISeederService _seeder;

    public BookController(ISeederService seeder)
    {
        _seeder = seeder;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {

        try
        {
            var books = _seeder.getBooksSeeder();
            return Ok(new
            {
                status = true,
                message = "Books fetched successfully",
                books
            });
        }
        catch (Exception ex)
        {

            return StatusCode(500, new
            {
                status = false,
                message = ex.Message,
            });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetOneBook(int id)
    {

        try
        {
            var books = _seeder.getBooksSeeder();

            if (id < 0 || id >= books.Count)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid Book Id"
                });
            }

            var book = books[id];

            return Ok(new
            {
                status = true,
                message = "Book fetched successfully",
                book
            });
        }
        catch (Exception ex)
        {

            return StatusCode(500, new
            {
                status = false,
                message = ex.Message,
            });
        }
    }

    [HttpPost("store")]
    public IActionResult StoreBook([FromBody] Book book)
    {
        try
        {
            var books = _seeder.getBooksSeeder();



            return Created($"http://localhost:5022/books/{books.Count - 1}", new
            {
                status = true,
                message = "Book created successfully",
                book
            });
        }
        catch (Exception ex)
        {

            return StatusCode(500, new
            {
                status = false,
                message = ex.Message,
            });
        }
    }

    [HttpPut("update")]
    public IActionResult UpdateBook([FromBody] BookUpdateDTO bookDTO)
    {
        try
        {
            var books = _seeder.getBooksSeeder();

            if (bookDTO.Id < 0 || bookDTO.Id >= books.Count)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid Book Id"
                });
            }

            Book book = bookDTO.GetBook();

            books[bookDTO.Id] = book;


            return Ok(new
            {
                status = true,
                message = "Book updated successfully",
                book,
            });
        }
        catch (Exception ex)
        {

            return StatusCode(500, new
            {
                status = false,
                message = ex.Message,
            });
        }
    }

    [HttpDelete("delete")]
    public IActionResult DeleteBook([FromBody] BookDeleteDTO bookDeleteDTO)
    {
        try
        {
            var books = _seeder.getBooksSeeder();

            if (bookDeleteDTO.Id < 0 || bookDeleteDTO.Id >= books.Count)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid Book Id"
                });
            }

            books.RemoveAt(bookDeleteDTO.Id);

            return Ok(new
            {
                status = true,
                message = "Book deleted successfully"
            });
        }
        catch (Exception ex)
        {

            return StatusCode(500, new
            {
                status = false,
                message = ex.Message,
            });
        }
    }

}
