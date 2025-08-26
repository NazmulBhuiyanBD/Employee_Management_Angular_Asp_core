using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Web_Api.Models
{
    public class Leave
    {
        public int LeaveId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId{get;set;}

        public string LeaveType { get; set; }
            //(Sick, Casual, Paid, Unpaid)

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }
            //(Pending, Approved, Rejected)
    }
}
