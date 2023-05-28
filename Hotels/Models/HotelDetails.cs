using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class HotelDetails
    {
        [Key]
        public int Hotel_Id { get; set; }
        [Required(ErrorMessage = "HotelName must be provided")]
        public string Hotel_Name { get; set; }
        [Required(ErrorMessage = "Location must be provided")]
        public string Hotel_Location { get; set; }
        [MinLength(10, ErrorMessage = " PhoneNumber should be minimum 10 chars long")]
        public string Hotel_Phonenumber { get; set; }
        public string Hotel_Amenities { get; set;}
        public int TotalNumberOfRooms { get; set; }
        

    }
}
