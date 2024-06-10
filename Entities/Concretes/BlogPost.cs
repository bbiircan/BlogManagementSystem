using Core.Entities;

namespace Entities.Concretes
{
    public class BlogPost : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User User { get; set; }

    }
}
