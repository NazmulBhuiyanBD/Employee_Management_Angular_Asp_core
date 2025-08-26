using System.ComponentModel.DataAnnotations;

namespace Employee_Web_Api.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        public string Title { get; set; }
            //(e.g., Software Engineer, HR Manager)

        public double Salary { get; set; }

    }
}
