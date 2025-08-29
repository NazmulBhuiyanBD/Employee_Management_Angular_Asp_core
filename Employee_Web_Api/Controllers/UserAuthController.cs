using Employee_Web_Api.ModelDTO;
using Employee_Web_Api.Models;
using Employee_Web_Api.Models.AppDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Employee_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly AppDbContext context;
        public UserAuthController(AppDbContext _context)
        {
            context = _context;
        }


        [HttpPost("register")]
        public async Task<IActionResult>Register(AuthDto dto)
        {
            var emp = await context.Employees.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if(emp==null)
            {
                return BadRequest("employee with this email not exits .contact Admin");
            }

            var exits = await context.UserAuths.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (exits!=null)
            {
                return BadRequest("Email Already Register");
            }

            var user = new UserAuth
            {
                Id=Guid.NewGuid(),
                Email = dto.Email,
                Password = dto.Password,
                EmployeeId=emp.EmployeeId,
                Role="Employee"
            };
            context.UserAuths.Add(user);
            await context.SaveChangesAsync();
            return Ok("Register Success");
        }
        [HttpPost("login")]
        public async Task<IActionResult>Login(AuthDto dto)
        {
            var emp = await context.UserAuths.Include(u => u.Employee).FirstOrDefaultAsync(u=>u.Email==dto.Email && u.Password==dto.Password && u.Role==dto.Role);

            if(emp==null)
            {
                return Unauthorized("Provide Proper Email & Password");
            }
            return Ok(
                new
                {
                    message = "Login Success",
                    emp.Email,
                    emp.Password,
                    emp.Role,
                    EmployeeName=emp.Employee.Name,
                }
                );
        }
    }
}
