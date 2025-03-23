using Microsoft.AspNetCore.Mvc;

namespace RETRA_HOTEL_SYSTEM_2.ViewModels
{
    public class UserAccountViewModel
    {
        public string FullName { get; set; }
        public string CompanyId { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
