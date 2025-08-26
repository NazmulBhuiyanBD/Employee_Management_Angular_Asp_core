using System.ComponentModel.DataAnnotations;

namespace Employee_Web_Api.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string Location { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
