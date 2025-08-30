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
    public class LeavesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeavesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaves()
        {
            var leaves = await _context.Leaves.ToListAsync();
            return Ok(leaves);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }

            return Ok(leave);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeave(int id, LeaveDto leave)
        {
            var empLeave = await _context.Leaves.FindAsync(id);
            if (empLeave ==null)
            {
                return NotFound();
            }
            var empId = await _context.Employees.FirstOrDefaultAsync(u=>u.EmployeeId==leave.EmployeeId);
            if(empId==null)
            {
                return NotFound("Employee Not Found");
            }
            empLeave.EmployeeId = leave.EmployeeId;
            empLeave.StartDate = leave.StartDate;
            empLeave.LeaveType = leave.LeaveType;
            empLeave.Status = leave.Status;
            empLeave.EndDate = leave.EndDate;
            await _context.SaveChangesAsync();
            return Ok(empLeave);
        }

        [HttpPost]
        public async Task<IActionResult> PostLeave(LeaveDto leave)
        {
            var empId = await _context.Employees.FirstOrDefaultAsync(u => u.EmployeeId == leave.EmployeeId);
            if(empId==null)
            {
                return NotFound("employee Not found");
            }
            var empLeave = new Leave
            {
                EmployeeId = leave.EmployeeId,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate=leave.EndDate,
                LeaveType=leave.LeaveType,
                Status=leave.Status

            };
            _context.Leaves.Add(empLeave);
            await _context.SaveChangesAsync();
            return Ok(empLeave);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            _context.Leaves.Remove(leave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
