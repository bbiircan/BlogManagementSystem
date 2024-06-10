namespace Business.Dtos.Requests.Comment
{
    public class CreateCommentRequest
    {
        public Guid BlogPostId { get; set; }
        public string Text { get; set; }
    }
}
