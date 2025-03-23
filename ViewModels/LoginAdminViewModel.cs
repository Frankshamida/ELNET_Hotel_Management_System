using System.ComponentModel.DataAnnotations;

namespace RETRA_HOTEL_SYSTEM_2.ViewModels
{
    public class LoginAdminViewModel
    {
        [Required(ErrorMessage = "Message is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password id required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    // Employee.cs
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

    // Room.cs
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public string RoomType { get; set; }
        public string BedType { get; set; }
        public decimal PricePerNight { get; set; }
        public string Status { get; set; }
        public int MaxOccupancy { get; set; }
        public string Amenities { get; set; }
        public string ImageUrl { get; set; }
    }

    // UserAccount.cs
    public class UserAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string CompanyId { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}
