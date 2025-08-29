using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Web_Api.Models
{
    public class Leave
    {
        [Key]
        public int LeaveId { get; set; }

        public int EmployeeId{get;set;}


        [ForeignKey("EmployeeId")]

        public Employee Employee { get; set; }

        [MaxLength(10)]
        [Required]

        public string LeaveType { get; set; }
        //(Sick, Casual, Paid, Unpaid)

        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Status { get; set; }
            //(Pending, Approved, Rejected)
    }
}
