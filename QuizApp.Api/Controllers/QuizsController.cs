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
    public class QuizsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuizsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Quizs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzes()
        {
            try
            {
                var currentUser = GetCurrentUser();
                return Ok(await _context.Quizzes.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Quizs/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Quiz>> GetQuiz(string name)
        {
            try
            {
                var currentUser = GetCurrentUser();
                return Ok(_context.Quizzes.Where(x => x.Name.Contains(name)));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutQuiz(int id, Quiz quiz)
        {
            try
            {
                var currentUser = GetCurrentUser();
                Quiz quiz1 = _context.Quizzes.FirstOrDefault(x => x.Id == id);
                if (quiz1 != null)
                {
                    quiz1.Name = quiz.Name;
                    quiz1.Description = quiz.Description;
                    quiz1.CategoryId = quiz.CategoryId;

                    _context.Quizzes.Update(quiz1);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    _context.Quizzes.Add(quiz);
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
        public async Task<ActionResult<Quiz>> PostQuiz(Quiz quiz)
        {
            try
            {
                var currentUser = GetCurrentUser();
                _context.Quizzes.Add(quiz);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Quizs/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            try
            {
                var currentUser = GetCurrentUser();
                var quiz = await _context.Quizzes.FirstOrDefaultAsync(x => x.Id == id);
                _context.Quizzes.Remove(quiz);
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
