using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ICommentDal : IAsyncRepository<Comment, Guid>, IRepository<Comment, Guid>
    {
    }
}
