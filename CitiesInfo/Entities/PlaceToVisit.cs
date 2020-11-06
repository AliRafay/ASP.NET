using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class PlaceToVisit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //generates automatic id in accordance with SQLServer
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; } //use later by using migrations

        [ForeignKey("CityId")]
        public City City { get; set; } //navigation property; this will connect placesToVisit to City, All others are column names
        public int CityId { get; set; }
    }
}