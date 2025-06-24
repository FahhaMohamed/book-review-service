public class BookUpdateDTO
{
    public required int Id { set; get; }
    public required string Title { set; get; }
    public required string Author { set; get; }
    public required string Genre { set; get; }

    public Book GetBook()
    {
        return new Book
        {
            Id = this.Id,
            Title = this.Title,
            Author = this.Author,
            Genre = this.Genre
        };
    }
}