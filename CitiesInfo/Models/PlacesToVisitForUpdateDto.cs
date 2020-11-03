
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PlacesToVisitForUpdateDto
    {
        //without id because we dont want the consumer to provide id
        [Required(ErrorMessage = "Please provide a name")] //System.ComponentModel.DataAnnotations for more
        [MaxLength(50, ErrorMessage = "Name should be less than 50")]
        public string Name { get; set; }
    }
}

