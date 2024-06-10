using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.User;
using Business.Dtos.Responses.User;
using Core.Entities;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IMapper _mapper;
        IUserDal _userDal;

        public UserManager(IMapper mapper, IUserDal userDal)
        {
            _mapper = mapper;
            _userDal = userDal;
        }

        public async Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest)
        {
            User user = _mapper.Map<User>(createUserRequest);
            var createdUser = await _userDal.AddAsync(user);
            CreatedUserResponse result = _mapper.Map<CreatedUserResponse>(createdUser);
            return result;
        }

        public async Task<User> GetByMailAsync(string mail, bool withDeleted)
        {
            var result = await _userDal.GetAsync(u => u.Email == mail, withDeleted: withDeleted);
            return result;
        }

        public List<IOperationClaim> GetClaims(IUser user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
