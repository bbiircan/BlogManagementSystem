using Core.Entities;

namespace Entities.Concretes
{
    public class User : Entity<Guid>, IUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public ICollection<Comment> Comments { get; set; } 
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
