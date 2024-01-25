using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebConsumAPI.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Owner Name")]
        
        public string OwnerName { get; set; }
        [Required]
        public string placename { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string placetype { get; set; }
        [Required]
        public DateTime date { get; set; }

        public string dateToShortDateString()
        {
            return date.ToShortDateString();
        }
    }

    
}
