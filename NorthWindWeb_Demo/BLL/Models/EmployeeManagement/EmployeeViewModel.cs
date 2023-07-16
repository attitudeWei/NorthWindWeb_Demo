using System.ComponentModel.DataAnnotations;

namespace NorthWindWeb_Demo.BLL.Models.EmployeeManagement
{
    public class EmployeeViewModel
    {
        public int? EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? City { get; set; }
    }
}
