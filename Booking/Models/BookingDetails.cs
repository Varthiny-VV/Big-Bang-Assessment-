using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class BookingDetails
    {
        [Key]
        public int Booking_Id { get; set; }
        public int Hotel_Id { get; set; }
        public string Hotel_Name { get; set;}
        public string UserName { get; set;}
        public int Room_Number { get; set; }
        public string Room_Type { get; set; }
        public string Room_Level { get; set; }
        public DateTime CheckIn_DateAndTime { get; set; }
        public DateTime CheckOut_DateAndTime { get; set;}
       
        
    }
}
