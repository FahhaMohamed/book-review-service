public class ReviewGetDTO
{
    public required Review review { set; get; }
    public required Book book { set; get; }



    public ReviewDetail GetDetail()
    {
        return new ReviewDetail(review, book);
    }
}

public class ReviewDetail
{
    public int Id { set; get; }
    public string User { set; get; }
    public double Rating { set; get; }
    public string Comment { set; get; }

    public Book book { set; get; }

    public ReviewDetail(Review review, Book book)
    {
        this.Id = review.Id;
        this.User = review.User;
        this.Rating = review.Rating;
        this.Comment = review.Comment;
        this.book = book;
    }
}