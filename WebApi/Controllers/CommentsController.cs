using Business.Abstracts;
using Business.Dtos.Requests.Comment;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateCommentRequest createCommentRequest)
        {
            var result = await _commentService.AddAsync(createCommentRequest);
            return Ok(result);
        }
    }
}
