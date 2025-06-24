using Newtonsoft.Json;

public class SeederService : ISeederService
{
    public List<Book> GetBooksSeeder()
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

    public void UpdateBooksSeeder(List<Book> books)
    {
        var toJson = JsonConvert.SerializeObject(books, Formatting.Indented);
        try
        {
            var filePathBook = Path.Combine(Directory.GetCurrentDirectory(), "data", "BookSeeder.json");
            if (!File.Exists(filePathBook))
            {
                throw new FileNotFoundException("BookSeeder.json Not Found");
            }

            File.WriteAllText(filePathBook, toJson);
        }
        catch (Exception ex)
        {

            throw new Exception($"Book Error: {ex.Message}");
        }
    }

    public List<Review> GetReviewSeeder()
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