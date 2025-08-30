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
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var dept = await _context.Departments.ToListAsync();
            return Ok(dept);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepDto department)
        {
            var dept = await _context.Departments.FindAsync(id);

            if (dept ==null)
            {
                return NotFound();
            }
            dept.DepartmentName = department.DepartmentName;
            await _context.SaveChangesAsync();
            return Ok(dept);
        }


        [HttpPost]
        public async Task<IActionResult> PostDepartment(DepDto department)
        {
            var dept = await _context.Departments.FirstOrDefaultAsync(u=>u.DepartmentName==department.DepartmentName);
            if(dept!=null)
            {
                return BadRequest("department already exits");
            }
            var newDept = new Department
            {
                DepartmentName = department.DepartmentName,
            };
            await _context.Departments.AddAsync(newDept);
            await _context.SaveChangesAsync();

            return Ok(newDept);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
