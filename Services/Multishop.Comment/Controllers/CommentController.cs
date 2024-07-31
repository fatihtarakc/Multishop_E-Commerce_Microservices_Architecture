using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Comment.Dtos.CommentDtos;
using Multishop.Comment.Services.Abstract;

namespace Multishop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("Comments")]
        public async Task<IActionResult> Comments()
        {
            var commentListDtos = await commentService.GetAllAsync();
            return Ok(commentListDtos);
        }

        [HttpGet("CommentsGetBy/{productId}")]
        public async Task<IActionResult> CommentsGetBy(string productId)
        {
            var commentListDtos = await commentService.GetAllWhereAsync(comment => comment.ProductId == productId);
            return Ok(commentListDtos);
        }

        [HttpGet("GetBy/{entityId}")]
        public async Task<IActionResult> GetBy(Guid entityId)
        {
            var commentDto = await commentService.GetFirstOrDefaultAsync(comment => comment.Id == entityId);
            if (commentDto is null) return NotFound("Searching comment was not found !");

            return Ok(commentDto);
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CommentAddDto entityAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool wasAdded = await commentService.AddAsync(entityAddDto);
            if (!wasAdded) return BadRequest("New comment added process is unsuccess !");

            return Ok("New comment was added successfully !");
        }

        [Authorize]
        [HttpDelete("Delete/{entityId}")]
        public async Task<IActionResult> Delete(Guid entityId)
        {
            bool wasDeleted = await commentService.DeleteAsync(entityId);
            if (!wasDeleted) return BadRequest("Comment deleted process is unsuccess !");

            return Ok("Comment was deleted successfully !");
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(CommentUpdateDto entityUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool wasUpdated = await commentService.UpdateAsync(entityUpdateDto);
            if (!wasUpdated) return BadRequest("Comment updated process is unsuccess !");

            return Ok("Comment was updated successfully !");
        }
    }
}