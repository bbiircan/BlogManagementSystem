namespace Business.Dtos.Requests.BlogPost
{
    public class GetListBlogPostRequest
    {
        public string FullName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
