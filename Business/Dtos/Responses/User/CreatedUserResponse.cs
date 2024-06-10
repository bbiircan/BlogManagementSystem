namespace Business.Dtos.Responses.User
{
    public class CreatedUserResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
