using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly ISeederService _seeder;
    private List<Book> _books;

    public BookController(ISeederService seeder)
    {
        _seeder = seeder;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {

        try
        {
            _books = _seeder.getBooksSeeder();
            return Ok(new
            {
                status = true,
                message = "Books fetched successfully",
                books = _books
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
