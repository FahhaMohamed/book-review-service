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
         _books = _seeder.getBooksSeeder();
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
       
        return Ok(new
        {
            status = true,
            message = "Books fetched successfully",
            books = _books
        });
    }
}
