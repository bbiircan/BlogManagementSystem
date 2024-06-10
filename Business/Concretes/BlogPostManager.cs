using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.BlogPost;
using Business.Dtos.Responses.BlogPost;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BlogPostManager : IBlogPostService
    {
        IMapper _mapper;
        IBlogPostDal _blogPostDal;
        IUserService _userService;
        BlogPostBusinessRules _blogPostBusinessRules;

        public BlogPostManager(IMapper mapper, IBlogPostDal blogPostDal, IUserService userService, BlogPostBusinessRules blogPostBusinessRules)
        {
            _mapper = mapper;
            _blogPostDal = blogPostDal;
            _userService = userService;
            _blogPostBusinessRules = blogPostBusinessRules;
        }

        public async Task<CreatedBlogPostResponse> AddAsync(CreateBlogPostRequest createBlogPostRequest)
        {
            BlogPost blogPost = _mapper.Map<BlogPost>(createBlogPostRequest);
            var createdBlogPost = await _blogPostDal.AddAsync(blogPost);
            CreatedBlogPostResponse createdBlogPostResponse = _mapper.Map<CreatedBlogPostResponse>(createdBlogPost);
            return createdBlogPostResponse;
        }

        public async Task<DeletedBlogPostResponse> DeleteAsync(DeleteBlogPostRequest deleteBlogPostRequest)
        {
            BlogPost blogPost = await _blogPostBusinessRules.CheckIfExistsById(deleteBlogPostRequest.Id);
            var deletedBlogPost = await _blogPostDal.DeleteAsync(blogPost);
            DeletedBlogPostResponse deletedBlogPostResponse = _mapper.Map<DeletedBlogPostResponse>(deletedBlogPost);
            return deletedBlogPostResponse;
        }

        public async Task<IPaginate<GetListBlogPostResponse>> GetListAsync(PageRequest pageRequest)
        {
            var result = await _blogPostDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListBlogPostResponse>>(result);
        }

        public async Task<IPaginate<BlogPostFilterResponse>> GetListByUserIdAsync(Guid userId, PageRequest pageRequest)
        {

            var result = await _blogPostDal.GetListAsync(p => p.UserId == userId, index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<IPaginate<BlogPostFilterResponse>>(result);
        }

        public async Task<UpdatedBlogPostResponse> UpdateAsync(UpdateBlogPostRequest updateBlogPostRequest)
        {
            BlogPost blogPost = await _blogPostBusinessRules.CheckIfExistsById(updateBlogPostRequest.Id);
            _mapper.Map(updateBlogPostRequest, blogPost);
            var updatedBlogPost = await _blogPostDal.UpdateAsync(blogPost);
            UpdatedBlogPostResponse updatedBlogPostResponse = _mapper.Map<UpdatedBlogPostResponse>(updatedBlogPost);
            return updatedBlogPostResponse;
        }
    }
}
