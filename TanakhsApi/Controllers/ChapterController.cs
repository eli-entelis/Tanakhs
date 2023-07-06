using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TanakhsApi.Entities;

namespace TanakhsApi.Controllers
{
    public class ChapterController : BackendControllerBase
    {
        private readonly TanakhsContext _context;
        private readonly ILogger<ChapterController> _logger;

        public ChapterController(TanakhsContext context, ILogger<ChapterController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Chapter chapter)
        {
            User existingUser = await _context.Users.FirstOrDefaultAsync(
                u => u.Id == chapter.Author.Id
            );

            if (existingUser != null)
            {
                // Assign the existing user's ID to the BlogPost's User
                chapter.Author = existingUser;
            }
            chapter.Comments.Clear();

            _context.BlogPosts.Add(chapter);
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Failed to save the Post."); // Return a BadRequest response with an error message
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BlogPost blogPost)
        {
            try
            {
                var existingBlogPost = await _context.BlogPosts.FindAsync(blogPost.Id);

                if (existingBlogPost != null)
                {
                    existingBlogPost.Title = blogPost.Title;
                    existingBlogPost.Author = blogPost.Author;
                    existingBlogPost.Tags = blogPost.Tags;

                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound(); // Return a NotFound response if the blog post with the given ID is not found
                }
            }
            catch (Exception)
            {
                return BadRequest("Failed to update the blog post."); // Return a BadRequest response with an error message
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var chapter = await _context.Chapters
                    .Include(c => c.Comments) // Include the Comments navigation property
                    .Include(c => c.Tags)
                    .Include(c => c.ChapterRating)
                    .SingleOrDefaultAsync(c => c.Id == id);

                if (chapter != null)
                {
                    // Remove the associated comments
                    _context.Verses.RemoveRange(chapter.Verses);
                    _context.Comments.RemoveRange(chapter.Comments);
                    chapter.Tags.Clear();
                    // Delete the blog post
                    _context.Chapters.Remove(chapter);

                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound(); // Return a NotFound response if the blog post with the given ID is not found
                }
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete the blog post."); // Return a BadRequest response with an error message
            }
        }
    }
}
