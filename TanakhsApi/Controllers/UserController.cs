using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TanakhsApi.Entities;

namespace TanakhsApi.Controllers
{
    public class UserController : BackendControllerBase
    {
        private readonly TanakhsContext _context;
        private readonly ILogger<ChapterController> _logger;

        public UserController(TanakhsContext context, ILogger<ChapterController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var query = Request.QueryString.ToString();
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse", new { query = query }),
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var encodedQuery = HttpContext.Request.Query["query"].ToString();
            var query = WebUtility.UrlDecode(encodedQuery);
            var returnUrl = query.Replace("?ReturnUrl=", "");
            var result = await HttpContext.AuthenticateAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );
            var claims = result.Principal.Identities
                .FirstOrDefault()
                .Claims.Select(
                    claim =>
                        new
                        {
                            claim.Issuer,
                            claim.OriginalIssuer,
                            claim.Type,
                            claim.Value
                        }
                );
            return Redirect("https://localhost:7270" + returnUrl);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var u = this.User;
            var user = await _context.Users
                .Where(u => u.Id == id)
                .IgnoreAutoIncludes()
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound($"User with ID: {id}, not found");
            return Ok(user);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
                return NotFound($"User with ID: {user.Id}, not found");
            try
            {
                existingUser.Religion = user.Religion;
                existingUser.Email = user.Email;
                existingUser.Name = user.Name;
                existingUser.GivenName = user.GivenName;
                existingUser.FamilyName = user.FamilyName;
                existingUser.Gender = user.Gender;
                existingUser.ProfilePictureUrl = user.ProfilePictureUrl;

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(c => c.Id == id);

                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return Ok();
                }

                return NotFound(); // Return a NotFound response if the blog post with the given ID is not found
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete user with user."); // Return a BadRequest response with an error message
            }
        }
    }
}
