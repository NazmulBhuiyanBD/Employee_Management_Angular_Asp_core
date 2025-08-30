using Employee_Web_Api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Web_Api.ModelDTO
{
    public class LeaveDto
    {
        public int LeaveId { get; set; }

        public int EmployeeId { get; set; }

        public string LeaveType { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Status { get; set; }
    }
}
