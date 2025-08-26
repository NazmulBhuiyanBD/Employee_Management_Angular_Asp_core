using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Employee_Web_Api.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }


    }
}
