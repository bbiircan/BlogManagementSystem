using Business.Dtos.Requests.User;
using Business.Dtos.Responses.User;
using Core.Entities;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest);
        Task<User> GetByMailAsync(string mail, bool withDeleted);
        List<IOperationClaim> GetClaims(IUser user);

    }
}
