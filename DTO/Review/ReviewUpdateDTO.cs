public class ReviewUpdateDTO
{
    public required int Id { set; get; }
    public required int BookId { set; get; }
    public required string User { set; get; }
    public required double Rating { set; get; }
    public required string Comment { set; get; }

    public Review GetReview()
    {
        return new Review
        {
            Id = this.Id,
            BookId = this.BookId,
            User = this.User,
            Rating = this.Rating,
            Comment = this.Comment,
        };
    }
}