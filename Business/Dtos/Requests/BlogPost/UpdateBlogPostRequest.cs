namespace Business.Dtos.Requests.BlogPost
{
    public class UpdateBlogPostRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
