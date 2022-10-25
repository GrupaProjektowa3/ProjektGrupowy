using System;
using System.Collections.Generic;
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
    public class LoggedInUsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoggedInUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LoggedInUsers
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<LoggedInUser>>> GetUsers()
        {
            try
            {
                var currentUser = GetCurrentUser();
                return Ok(await _context.Users.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/LoggedInUsers/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<LoggedInUser>> GetLoggedInUser(int id)
        {
            try
            {
                var currentUser = GetCurrentUser();
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(user);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
        }

        // PUT: api/LoggedInUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutLoggedInUser(int id, LoggedInUser loggedInUser)
        {
            try
            {
                var currentUser = GetCurrentUser();
                LoggedInUser user1 = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user1 != null)
                {
                    user1.RoleValue = loggedInUser.UserName;
                    _context.Users.Update(user1);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    _context.Users.Add(loggedInUser);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/LoggedInUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<LoggedInUser>> PostLoggedInUser(LoggedInUser loggedInUser)
        {
            try
            {
                var currentUser = GetCurrentUser();
                _context.Users.Add(loggedInUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/LoggedInUsers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLoggedInUser(int id)
        {
            try
            {
                var currentUser = GetCurrentUser();
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                _context.Users.Remove(user);
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
