public class Review
{
    public int Id { set; get; }
    public required int BookId { set; get; }
    public required string User { set; get; }
    public required double Rating { set; get; }
    public required string Comment { set; get; }

}