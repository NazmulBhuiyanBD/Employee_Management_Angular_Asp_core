using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Web_Api.Models;
using Employee_Web_Api.Models.AppDb;
using Employee_Web_Api.ModelDTO;

namespace Employee_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var emp = await _context.Employees.Include(e=>e.Department).ToListAsync();
            return Ok(emp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            return Ok(emp);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id,EmployeeDto employee)
        {

            var emp = await _context.Employees.Include(e=>e.Department).FirstOrDefaultAsync(d=>d.EmployeeId==id);
            if(emp==null)
            {
                return NotFound();
            }

            emp.Email = employee.Email;
            emp.Name = employee.Name;
            emp.Phone = employee.Phone;
            emp.DateOfBirth = employee.DateOfBirth;
            emp.Salary = employee.Salary;
            emp.Gender = employee.Gender;
            emp.Address = employee.Address;
            emp.DepartmentId = employee.DepartmentId;

            await _context.SaveChangesAsync();
            return Ok(emp);


        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDto employee)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Email == employee.Email);
            if(emp!=null)
            {
                return BadRequest("Email Already exits");
            }
            var dept = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == employee.DepartmentId);
            if (dept == null)
            {
                return BadRequest("Invalid DepartmentId");
            }

            var newemp = new Employee {
                Email = employee.Email,
                Name = employee.Name,
                Phone = employee.Phone,
                DateOfBirth = employee.DateOfBirth,
                Salary = employee.Salary,
                Gender = employee.Gender,
                Address = employee.Address,
                DepartmentId = employee.DepartmentId,
                Department = dept
            };

            await _context.Employees.AddAsync(newemp);
            await _context.SaveChangesAsync();

            return Ok(newemp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
