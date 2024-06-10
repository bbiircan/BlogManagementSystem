using Business.Abstracts;
using Business.Dtos.Requests.BlogPost;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateBlogPostRequest createBlogPostRequest)
        {
            var result = await _blogPostService.AddAsync(createBlogPostRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete([FromBody] DeleteBlogPostRequest deleteBlogPostRequest)
        {
            var result = await _blogPostService.DeleteAsync(deleteBlogPostRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] UpdateBlogPostRequest updateBlogPostRequest)
        {
            var result = await _blogPostService.UpdateAsync(updateBlogPostRequest);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _blogPostService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<ActionResult> GetListByUserId([FromQuery] Guid userId, PageRequest pageRequest)
        {
            var result = await _blogPostService.GetListByUserIdAsync(userId, pageRequest);
            return Ok(result);
        }
    }
}
    

