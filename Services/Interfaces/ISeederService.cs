public interface ISeederService
{
    List<Book> GetBooksSeeder();
    List<Review> GetReviewSeeder();
    void UpdateBooksSeeder(List<Book> books);
}