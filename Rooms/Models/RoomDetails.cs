using System.ComponentModel.DataAnnotations;

namespace Rooms.Models
{
    public class RoomDetails
    {
        [Key]
        public int Room_Id { get; set; }
        
        public int Hotel_Id { get; set; }
        [Required(ErrorMessage = "Room Number must be provided")]
        public int Room_Number { get; set; }
        public string Room_Type { get; set; }
        public string Room_Level { get;set; }
        public float Room_Price { get; set; }
        [Required(ErrorMessage = "Room availability status must be provided")]
        public string Room_Availability { get; set; }

    }
}
