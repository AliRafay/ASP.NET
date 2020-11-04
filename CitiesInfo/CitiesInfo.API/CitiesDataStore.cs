using Models;
using System.Collections.Generic;

namespace CitiesInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore StaticDataStoreObj { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id=1,
                    Name="Karachi",
                    Description="City of Lights",
                    PlacesToVisit= new List<PlacesToVisitDto>
                    {
                        new PlacesToVisitDto()
                        {
                            Id=1,
                            Name="Chunky Monkey",
                            Description="Amusement Park"
                        },
                        new PlacesToVisitDto()
                        {
                            Id=2,
                            Name="Mazar e Quaid",
                            Description="Mohammad Ali Jinnah Grave"

                        }
                    }
                },
                new CityDto()
                {
                    Id=2,
                    Name="Lahore",
                    Description="Orange train wali city",
                    PlacesToVisit = new List<PlacesToVisitDto>
                    {
                        new PlacesToVisitDto()
                        {
                            Id=3,
                            Name="Orange Train",
                            Description="PMLN's train plan"

                        },
                        new PlacesToVisitDto()
                        {
                            Id=4,
                            Name="Badshahi Mosque",
                            Description="red mosque"

                        },
                        new PlacesToVisitDto()
                        {
                            Id=5,
                            Name="Lahore Fort",
                            Description="An old fort of Lahore"

                        }
                    }
                },
                new CityDto()
                {
                    Id=3,
                    Name="Jamshoro",
                    Description="City of Text Books",
                    PlacesToVisit= new List<PlacesToVisitDto>
                    {
                        new PlacesToVisitDto()
                        {
                            Id=6,
                            Name="Rani Kot Fort",
                            Description="Fort of Rani Kot"

                        }
                    }
                },
            };
        }
    }
}
