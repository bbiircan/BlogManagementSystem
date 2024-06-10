using Core.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class BlogPostBusinessRules : BaseBusinessRules<BlogPost>
    {
        IBlogPostDal _blogPostDal;

        public BlogPostBusinessRules(IBlogPostDal blogPostDal) : base(blogPostDal)
        {
            _blogPostDal = blogPostDal;
        }
    }
}
