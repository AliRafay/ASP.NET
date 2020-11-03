using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class PlacesToVisitForCreationDto
    {
        //without id because we dont want the consumer to provide id
        public string Name { get; set; }
    }
}
