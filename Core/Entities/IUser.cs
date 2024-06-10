namespace Core.Entities;
public interface IUser
{
    public Guid Id { get; set; }
    string FullName { get; set; }
    string Email { get; set; }
    byte[] PasswordSalt { get; set; }
    byte[] PasswordHash { get; set; }
}