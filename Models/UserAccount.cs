using Microsoft.AspNetCore.Mvc;

namespace RETRA_HOTEL_SYSTEM_2.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}