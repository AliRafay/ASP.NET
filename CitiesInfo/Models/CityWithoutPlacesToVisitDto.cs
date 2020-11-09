using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    //we put a choice for placesToVisit , if we use cityDto then there will be a empty placesToVisit and number of placesToVisit
    public class CityWithoutPlacesToVisitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
