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
                            Name="Chunky Monkey"
                        },
                        new PlacesToVisitDto()
                        {
                            Id=2,
                            Name="Mazar e Quaid"
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
                            Id=1,
                            Name="Orange Train"
                        },
                        new PlacesToVisitDto()
                        {
                            Id=2,
                            Name="Badshahi Mosque"
                        },
                        new PlacesToVisitDto()
                        {
                            Id=3,
                            Name="Lahore Fort"
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
                            Id=1,
                            Name="Rani Kot Fort"
                        }
                    }
                },
            };
        }
    }
}
