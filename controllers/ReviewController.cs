using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("reviews")]

public class ReviewController : ControllerBase
{
    private readonly ISeederService _seeder;
    public ReviewController(ISeederService seeder)
    {
        _seeder = seeder;
    }

    [HttpGet]
    public IActionResult GetAllReviews()
    {
        try
        {
            var reviews = _seeder.GetReviewSeeder();
            return Ok(new
            {
                status = true,
                message = "Reviews fetched successfully",
                reviews,
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
    public IActionResult GetOneReview(int id)
    {

        try
        {
            var reviews = _seeder.GetReviewSeeder();

            if (id < 0 || id >= reviews.Count)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid Review Id",
                });
            }
            return Ok(new
            {
                status = true,
                message = "Reviews fetched successfully",
                review = reviews[id],
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
    public IActionResult AddReview(Review review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                status = false,
                message = "All fields required"
            });
        }



        try
        {
            var books = _seeder.GetBooksSeeder();
            var reviews = _seeder.GetReviewSeeder();

            books = books.Where(book => book.Id == review.BookId).ToList();

            if (books.Count == 0)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "No books available for the given Book ID"
                });
            }

            int newId = reviews.Count;

            review.Id = newId;


            return Created($"http://localhost:5022/reviews/{newId}", new
            {
                status = true,
                message = "Review added successfully",
                review,
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
    public IActionResult UpdateReview(ReviewUpdateDTO review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                status = false,
                message = "All fields required"
            });
        }

        try
        {
            var reviews = _seeder.GetReviewSeeder();

            if (review.Id < 0 || review.Id >= reviews.Count)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid Review Id",
                });
            }



            if (reviews[review.Id].BookId != review.BookId)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "No books available for the given Book ID"
                });
            }

            reviews[review.Id] = review.GetReview();

            return Ok(new
            {
                status = true,
                message = "Review updated succesfully",
                review
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
    public IActionResult DeleteReview(DeleteReviewDTO review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                status = false,
                message = "All fields required"
            });
        }

        try
        {
            var reviews = _seeder.GetReviewSeeder();

            if (review.Id < 0 || review.Id >= reviews.Count)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid Review Id",
                });
            }

            if (reviews[review.Id].BookId != review.BookId)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "No books available for the given Book ID"
                });
            }

            reviews.RemoveAt(review.Id);

            return Ok(new
            {
                status = true,
                message = "Review deleted succesfully",
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