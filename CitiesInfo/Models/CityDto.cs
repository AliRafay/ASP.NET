using System.Collections.Generic;

namespace Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPlacesToVisit
        {
            get
            {
                return PlacesToVisit.Count;
            }
        }
        public List<PlacesToVisitDto> PlacesToVisit { get; set; } = new List<PlacesToVisitDto>();
        
    }
}
