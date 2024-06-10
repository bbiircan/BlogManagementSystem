using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;


namespace DataAccess.Concretes.EntityFramework;
public class EfBlogPostDal : EfRepositoryBase<BlogPost, Guid, BlogManagementSystemContext>, IBlogPostDal
{
    public EfBlogPostDal(BlogManagementSystemContext context) : base(context)
    {
    }
}

