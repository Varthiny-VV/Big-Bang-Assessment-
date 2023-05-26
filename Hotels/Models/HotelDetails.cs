using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class HotelDetails
    {
        [Key]
        public int Hotel_Id { get; set; }
        public string Hotel_Name { get; set; }
        public string Hotel_Location { get; set; }
        public string Hotel_Phonenumber { get; set; }
        public string Hotel_Amenities { get; set;}
        public int TotalNumberOfRooms { get; set; }
        

    }
}
