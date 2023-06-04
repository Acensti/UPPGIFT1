using Apibackend.Models.Dtos;
using Apibackend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Apibackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentRepository _commentRepository;

        public CommentsController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(Comment comment)
        {
            return Ok(await _commentRepository.AddAsync(comment));
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> RetrieveAllAsync()
        {
            return Ok(await _commentRepository.RetrieveAllAsync());
        }
    }
}
