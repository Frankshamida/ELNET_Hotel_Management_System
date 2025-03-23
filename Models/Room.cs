using Microsoft.AspNetCore.Mvc;

namespace RETRA_HOTEL_SYSTEM_2.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public string BedType { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public string Status { get; set; } = string.Empty;
        public int MaxOccupancy { get; set; }
        public string Amenities { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}