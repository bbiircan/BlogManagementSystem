using Business.Dtos.Requests.Comment;
using Business.Dtos.Responses.Comment;

namespace Business.Abstracts
{
    public interface ICommentService
    {
        Task<CreatedCommentResponse> AddAsync(CreateCommentRequest createCommentRequest);

    }
}
