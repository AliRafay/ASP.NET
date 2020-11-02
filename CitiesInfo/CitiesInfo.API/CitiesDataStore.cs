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
                    Description="City of Lights"
                },
                new CityDto()
                {
                    Id=2,
                    Name="Lahore",
                    Description="Orange train wali city"
                },
                new CityDto()
                {
                    Id=3,
                    Name="Jamshoro",
                    Description="City of Text Books"
                },
            };
        }
    }
}
