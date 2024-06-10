using Business.Abstracts;
using Business.Dtos.Requests.Comment;
using Business.Dtos.Responses.Comment;

namespace Business.Concretes
{
    public class CommentManager : ICommentService
    {
        ICommentService _commentService;

        public CommentManager(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<CreatedCommentResponse> AddAsync(CreateCommentRequest createCommentRequest)
        {
            return await _commentService.AddAsync(createCommentRequest);
        }
    }
}
