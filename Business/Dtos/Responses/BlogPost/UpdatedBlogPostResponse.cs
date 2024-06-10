namespace Business.Dtos.Responses.BlogPost
{
    public class UpdatedBlogPostResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
