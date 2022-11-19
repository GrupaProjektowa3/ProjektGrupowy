using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL;
using QuizApp.Model;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            try
            {
                var currentUser = GetCurrentUser();
                return Ok(await _context.Images.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Images/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Image>> GetImage(int id)
        {
            try
            {
                var currentUser = GetCurrentUser();
                var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(image);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutImage(int id, Image image)
        {
            try
            {
                var currentUser = GetCurrentUser();
                Image image1 = _context.Images.FirstOrDefault(x => x.Id == id);
                if (image != null)
                {
                    image1.Name = image.Name;
                    image1.Description = image.Description;
                    image1.CategoryId = image.CategoryId;
                    _context.Images.Update(image1);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    _context.Images.Add(image);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            try
            {
                var currentUser = GetCurrentUser();
                _context.Images.Add(image);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            try
            {
                var currentUser = GetCurrentUser();
                var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        private LoggedInUser GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new LoggedInUser
                {
                    FirstName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                    EmailAdress = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    RoleValue = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
