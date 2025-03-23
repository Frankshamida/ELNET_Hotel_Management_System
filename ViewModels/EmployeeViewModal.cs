using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RETRA_HOTEL_SYSTEM_2.ViewModels
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string CompanyId { get; set; }
    }
}