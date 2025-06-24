using Newtonsoft.Json;

public class SeederService : ISeederService
{
    private readonly List<Book> _books;
    private readonly List<Review> _reviews;

    public SeederService()
    {
        var filePathBook = Path.Combine(Directory.GetCurrentDirectory(), "data", "BookSeeder.json");
        var filePathReview = Path.Combine(Directory.GetCurrentDirectory(), "data", "ReviewSeeder.json");
        var jsonBook = File.ReadAllText(filePathBook);
        var jsonReview = File.ReadAllText(filePathReview);
        _books = JsonConvert.DeserializeObject<List<Book>>(jsonBook) ?? new List<Book>();
        _reviews = JsonConvert.DeserializeObject<List<Review>>(jsonReview) ?? new List<Review>();
    }

    public List<Book> getBooksSeeder()
    {
        return _books;
    }

    public List<Review> getReviewSeeder()
    {
        return _reviews;
    }
}