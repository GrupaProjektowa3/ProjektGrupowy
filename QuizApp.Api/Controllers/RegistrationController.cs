using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Model;
using System.Data;
using System.Threading.Tasks;
using System;
using QuizApp.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(LoggedInUser user)
        {
            try
            {
                var valideUser = CreateUser(user);
                if (valideUser == null)
                {
                    return BadRequest();
                }
                SHA256 sha256 = SHA256.Create();
                byte[] b = Encoding.ASCII.GetBytes(valideUser.Password);
                byte[] hash = sha256.ComputeHash(b);
                StringBuilder sb = new StringBuilder();
                foreach (var item in hash)
                {
                    sb.Append(item.ToString("X2"));
                }
                valideUser.Password = Convert.ToString(sb);
                valideUser.RoleValue = "LoggedInUser";
                _context.Users.Add(valideUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private LoggedInUser CreateUser(LoggedInUser user)
        {
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                return null;
            }
            else
                return user;
        }
    }
}
