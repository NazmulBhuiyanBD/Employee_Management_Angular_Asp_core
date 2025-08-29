using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Web_Api.Models
{
    public class UserAuth
    {
        [Key]
        public Guid Id { get; set; }

        [Required,MaxLength(50)]
        public string Email { get; set; }

        [Required,MaxLength(50)]
        public string Password { get; set; }
        public string Role { get; set; } = "Employee";

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]

        public Employee Employee { get; set; }
    }
}
