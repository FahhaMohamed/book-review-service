using Newtonsoft.Json;

public class SeederService : ISeederService
{
    public List<Book> getBooksSeeder()
    {
        try
        {
            var filePathBook = Path.Combine(Directory.GetCurrentDirectory(), "data", "BookSeeder.json");
            if (!File.Exists(filePathBook))
            {
                throw new FileNotFoundException("BookSeeder.json Not Found");
            }

            var jsonBook = File.ReadAllText(filePathBook);
            var books = JsonConvert.DeserializeObject<List<Book>>(jsonBook) ?? new List<Book>();
            return books;
        }
        catch (Exception ex)
        {

            throw new Exception($"Book Error: {ex.Message}");
        }
    }

    public List<Review> getReviewSeeder()
    {
        var filePathReview = Path.Combine(Directory.GetCurrentDirectory(), "data", "ReviewSeeder.json");
        if (!File.Exists(filePathReview))
        {
            throw new FileNotFoundException("ReviewSeeder.json not Found");
        }
        var jsonReview = File.ReadAllText(filePathReview);
        var reviews = JsonConvert.DeserializeObject<List<Review>>(jsonReview) ?? new List<Review>();
        return reviews;
    }
}