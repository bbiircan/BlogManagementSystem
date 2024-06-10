namespace Business.Dtos.Responses.BlogPost
{
    public class GetListBlogPostResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
