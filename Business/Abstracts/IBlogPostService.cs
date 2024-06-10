using Business.Dtos.Requests.BlogPost;
using Business.Dtos.Responses.BlogPost;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IBlogPostService
    {
        Task<CreatedBlogPostResponse> AddAsync(CreateBlogPostRequest createBlogPostRequest);
        Task<DeletedBlogPostResponse> DeleteAsync(DeleteBlogPostRequest deleteBlogPostRequest);
        Task<UpdatedBlogPostResponse> UpdateAsync(UpdateBlogPostRequest updateBlogPostRequest);
        Task<IPaginate<GetListBlogPostResponse>> GetListAsync(PageRequest pageRequest);
        Task<IPaginate<BlogPostFilterResponse>> GetListByUserIdAsync(Guid userId, PageRequest pageRequest);

    }
}
