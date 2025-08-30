using Employee_Web_Api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Web_Api.ModelDTO
{
    public class EmployeeDto
    {

            [Required, MaxLength(50)]
            public string Name { get; set; }

            [Required, MaxLength(50)]
            public string Email { get; set; }

            [Required, MaxLength(15)]
            public string Phone { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string Address { get; set; }
            public double Salary { get; set; }

            public int DepartmentId { get; set; }

    }
}
