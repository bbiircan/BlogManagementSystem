namespace Business.Dtos.Responses.Comment
{
    public class CreatedCommentResponse
    {
        public Guid Id { get; set; }
        public Guid BlogPostId { get; set; }
        public string FullName { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
