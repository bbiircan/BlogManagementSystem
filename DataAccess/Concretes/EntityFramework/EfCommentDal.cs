using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;


namespace DataAccess.Concretes.EntityFramework;
public class EfCommentDal : EfRepositoryBase<Comment, Guid, BlogManagementSystemContext>, ICommentDal
{
    public EfCommentDal(BlogManagementSystemContext context) : base(context)
    {
    }
}

