using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class BookingDetails
    {
        [Key]
        public int Booking_Id { get; set; }
        public int Hotel_Id { get; set; }
        public string Hotel_Name { get; set;}
        [Required(ErrorMessage = "Hotel Name should be provided for booking")]
        public string UserName { get; set;}
        [Required(ErrorMessage = "UserName should be provided for booking")]
        public int Room_Number { get; set; }
        public string Room_Type { get; set; }
        public string Room_Level { get; set; }
        [Required(ErrorMessage = "ChekIn details must be provided")]
        public DateTime CheckIn_DateAndTime { get; set; }
        [Required(ErrorMessage = "CheckOut details must be provided")]
        public DateTime CheckOut_DateAndTime { get; set;}
       
        
    }
}
