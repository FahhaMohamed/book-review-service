public class BookGetDTO
{
    public required Book Book { set; get; }
    public required List<Review> Reviews { set; get; }

    public BookDetail GetDetail()
    {
        var bookDetail = new BookDetail(Book, Reviews);
        return bookDetail;
    }
}


public class BookDetail
{
    public int Id { set; get; }
    public string Title { set; get; }
    public string Author { set; get; }
    public string Genre { set; get; }

    public List<Review> Reviews { set; get; }

    public BookDetail(Book book, List<Review> reviews)
    {
        this.Id = book.Id;
        this.Title = book.Title;
        this.Author = book.Author;
        this.Genre = book.Genre;
        this.Reviews = reviews;
    }
}