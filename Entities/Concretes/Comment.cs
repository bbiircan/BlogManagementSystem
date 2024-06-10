using Core.Entities;

namespace Entities.Concretes
{
    public class Comment : Entity<Guid>
    {
        public Guid BlogPostId { get; set; }
        public string FullName { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.UtcNow;
        public User User { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
