using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PlacesToVisitForCreationDto
    {
        //without id because we dont want the consumer to provide id
        [Required(ErrorMessage = "Please provide a name")] //System.ComponentModel.DataAnnotations for more
        [MaxLength(50,ErrorMessage ="Name should be less than 50")]
        public string Name { get; set; }

        [MaxLength(150, ErrorMessage = "Desc should be less than 150")]
        public string Description { get; set; }

    }
}
