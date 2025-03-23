using Microsoft.AspNetCore.Identity;

namespace RETRA_HOTEL_SYSTEM_2.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}