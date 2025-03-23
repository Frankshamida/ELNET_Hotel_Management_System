using Microsoft.AspNetCore.Mvc;

namespace RETRA_HOTEL_SYSTEM_2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
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