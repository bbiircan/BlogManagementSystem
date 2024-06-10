using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IBlogPostDal : IAsyncRepository<BlogPost, Guid>, IRepository<BlogPost, Guid>
    {
    }
}
