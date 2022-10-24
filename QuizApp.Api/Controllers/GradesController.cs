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
    public class GradesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            try
            {
                return Ok(await _context.Grades.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            try
            {
                var grade = await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(grade);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            try
            {
                Grade grade1 = _context.Grades.FirstOrDefault(x => x.Id == id);
                if (grade1 != null)
                {
                    grade1.DateOfIssue = grade.DateOfIssue;
                    grade1.GradeValue = grade.GradeValue;
                    if (grade.CategoryId != null)
                    {
                        grade1.CategoryId = grade.CategoryId;
                    }
                    if (grade.LoggedInUserId != null)
                    {
                        grade1.LoggedInUserId = grade.LoggedInUserId;
                    }
                    _context.Grades.Update(grade);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    _context.Grades.Add(grade);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            try
            {
                _context.Grades.Add(grade);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            try
            {
                var grade = await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);
                _context.Grades.Remove(grade);
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
