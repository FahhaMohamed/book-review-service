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
            var books = _seeder.GetBooksSeeder();
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
            var books = _seeder.GetBooksSeeder();
            var reviews = _seeder.GetReviewSeeder();


            if (id < 0 || id >= books.Count)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid Book Id"
                });
            }

            var book = books[id];
            reviews = reviews.Where(review => review.BookId == id).ToList();

            var bookDetail = new BookGetDTO
            {
                Book = book,
                Reviews = reviews
             };

            return Ok(new
            {
                status = true,
                message = "Book fetched successfully",
                book = bookDetail.GetDetail()
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
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                status = false,
                message = "All feilds required"
            });
        }

        try
        {
            var books = _seeder.GetBooksSeeder();

            int newId = books.Count;

            book.Id = newId;

            books.Add(book);

            _seeder.UpdateBooksSeeder(books);

            return Created($"http://localhost:5022/books/{newId}", new
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

        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                status = false,
                message = "All feilds required"
            });
        }

        try
        {
            var books = _seeder.GetBooksSeeder();

            var reviews = _seeder.GetReviewSeeder();

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



            _seeder.UpdateBooksSeeder(books);

            reviews = reviews.Where(review => review.BookId == book.Id).ToList();

            var bookDetail = new BookGetDTO
            {
                Book = book,
                Reviews = reviews
             };

            return Ok(new
            {
                status = true,
                message = "Book updated successfully",
                book = bookDetail,
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
            var books = _seeder.GetBooksSeeder();

            if (bookDeleteDTO.Id < 0 || bookDeleteDTO.Id >= books.Count)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid Book Id"
                });
            }

            books.RemoveAt(bookDeleteDTO.Id);

            _seeder.UpdateBooksSeeder(books);

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
