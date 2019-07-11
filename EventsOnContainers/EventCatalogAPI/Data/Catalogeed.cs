using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class Catalogeed
    {
        public static void Seed(CatalogContext context)
        {
            context.Database.Migrate();
            if(!context.CatalogLocations.Any())
            {
                context.CatalogLocations.AddRange(GetPreConfiguredCatalogLocations());
                context.SaveChanges();
            }
            if (!context.CatalogEvents.Any())
            {
                context.CatalogEvents.AddRange(GetPreConfiguredCatalogEvents());
                context.SaveChanges();
            }
        }

        private static IEnumerable< CatalogEvent> GetPreConfiguredCatalogEvents()
        {
            return new List<CatalogEvent>()
                { new CatalogEvent(){EventName = "Latern Festival",
                    Date = DateTime.ParseExact( "2016-05-02","yyyy/dd/MM",null),Time= DateTime.ParseExact("null","null",null),
                    Description ="Connect with family and friends at the most beautiful event of the year, the " +
                    "1000 Lights Water Lantern Festival. ",Price=20,
                    PictureUrl ="http://externalcatalogbaseurltobereplaced/api/pic/6 ",ContactName="Seetha",
                    ContactNum =  9898989893,CatalogLocationId=1}

            };
        }

        private static IEnumerable<CatalogLocation> GetPreConfiguredCatalogLocations()
        {
            return new List<CatalogLocation>()
            { new CatalogLocation(){Name = "Junaita Beach Park",City="Kirkland",Zipcode= 98007,Address="16th street kirkland wa"},
              new CatalogLocation(){Name = "Idlewood Beach Park",City="Bellevue",Zipcode= 98010,Address="NE 14th street Bellevue"}

            };
        }
    }
}
