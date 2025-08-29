using System.ComponentModel.DataAnnotations;
using Employee_Web_Api.Models.AppDb;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace Employee_Web_Api.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [MinLength(5)]
        public string DepartmentName { get; set; }

    }

}
