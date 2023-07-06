using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TanakhsApi.Entities;

namespace TanakhsApi.Controllers
{
    public class BlogPostController : BackendControllerBase
    {
        private readonly TanakhsContext _context;
        private readonly ILogger<BlogPostController> _logger;

        public BlogPostController(TanakhsContext context, ILogger<BlogPostController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("GetPagePosts/{pageIndex}")]
        public async Task<IActionResult> GetPagePosts(int pageIndex)
        {
            int pageSize = 3;

            var blogPosts = _context.BlogPosts;
            var paginatedPosts = await PaginatedList<BlogPost>.CreateAsync(
                blogPosts,
                pageIndex,
                pageSize
            );
            foreach (var blogPost in paginatedPosts)
            {
                if (blogPost is Chapter chapter)

                    await _context.Entry(chapter).Reference(c => c.ChapterRating).LoadAsync();
            }

            return Ok(paginatedPosts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var blogPost = await _context.BlogPosts
                .Where(bp => bp.Id == id)
                .Include(bp => bp.Comments)
                .ThenInclude(c => c.Author)
                .Include(bp => bp.Author)
                .Include(bp => bp.Tags)
                .Include(bp => ((Chapter)bp).ChapterRating)
                .Include(bp => ((Chapter)bp).Verses)
                .FirstOrDefaultAsync();

            return Ok(blogPost); // Return the chapter as a response
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogPost blogPost)
        {
            User existingUser = await _context.Users.FirstOrDefaultAsync(
                u => u.Id == blogPost.Author.Id
            );

            if (existingUser != null)
            {
                // Assign the existing user's ID to the BlogPost's User
                blogPost.Author = existingUser;
            }
            blogPost.Comments.Clear();
            _context.BlogPosts.Add(blogPost);
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
                var blogPost = await _context.BlogPosts
                    .Include(bp => bp.Comments) // Include the Comments navigation property
                    .Include(bp => bp.Tags)
                    .SingleOrDefaultAsync(bp => bp.Id == id);

                if (blogPost != null)
                {
                    // Remove the associated comments
                    _context.Comments.RemoveRange(blogPost.Comments);
                    blogPost.Tags.Clear();
                    // Delete the blog post
                    _context.BlogPosts.Remove(blogPost);

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
