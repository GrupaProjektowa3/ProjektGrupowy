using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL;
using QuizApp.Model;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        {
            try
            {
                return Ok(await _context.Answers.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            try
            {
                var answer = await _context.Answers.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(answer);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
        }

        // PUT: api/Answers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {
            try
            {
                Answer answer1 = _context.Answers.FirstOrDefault(x => x.Id == id);
                if (answer1 != null)
                {
                    answer1.Title = answer.Title;
                    answer1.IsCorrect = answer.IsCorrect;
                    _context.Answers.Update(answer1);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    _context.Answers.Add(answer);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Answers
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
            try
            {
                _context.Answers.Add(answer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            try
            {
                var answer = await _context.Answers.FirstOrDefaultAsync(x => x.Id == id);
                _context.Answers.Remove(answer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
