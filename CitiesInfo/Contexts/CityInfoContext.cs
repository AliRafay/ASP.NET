using Entities;
using Microsoft.EntityFrameworkCore;
namespace Contexts
{
    //https://www.learnentityframeworkcore.com/connection-strings //ways to connect database to dbcontext
    public class CityInfoContext : DbContext
    {

        // One way to connect database to dbcontext

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=myDb;trusted_connection=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public CityInfoContext(DbContextOptions options) : base(options) //calling base class contructor
        {
            //Database.EnsureCreated();
            //We can also create database by Update-Database command in package manager console
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    City[] Cities =
        //    {
        //        new City()
        //        {
        //            Id=1,
        //            Name="Karachi",
        //            Description="City of Lights"
        //        },
        //        new City()
        //        {
        //            Id=2,
        //            Name="Lahore",
        //            Description="Orange train wali city"
        //        },
        //        new City()
        //        {
        //            Id=3,
        //            Name="Jamshoro",
        //            Description="City of Text Books"
        //        }
        //    };
        //    PlaceToVisit[] PlacesToVisit = {

        //        new PlaceToVisit()
        //        {
        //            CityId = 1,
        //            Id = 1,
        //            Name = "Chunky Monkey",
        //            Description = "Amusement Park"
        //        },
        //        new PlaceToVisit()
        //        {
        //            CityId = 1,
        //            Id = 2,
        //            Name = "Mazar e Quaid",
        //            Description = "Mohammad Ali Jinnah Grave"
        //        },
        //        new PlaceToVisit()
        //        {
        //            CityId = 2,
        //            Id = 3,
        //            Name = "Orange Train",
        //            Description = "PMLN's train plan"
        //        },
        //        new PlaceToVisit()
        //        {
        //            CityId = 2,
        //            Id = 4,
        //            Name = "Badshahi Mosque",
        //            Description = "red mosque"
        //        },
        //        new PlaceToVisit()
        //        {
        //            CityId = 2,
        //            Id = 5,
        //            Name = "Lahore Fort",
        //            Description = "An old fort of Lahore"
        //        },
        //        new PlaceToVisit()
        //        {
        //            CityId = 3,
        //            Id = 6,
        //            Name = "Rani Kot Fort",
        //            Description = "Fort of Rani Kot"

        //        }
        //    };
        //    modelBuilder.Entity<City>()     //For Manual Addition in database
        //            .HasData(Cities);

        //    modelBuilder.Entity<PlaceToVisit>()     //For Manual Addition in database
        //            .HasData(PlacesToVisit);

        //    base.OnModelCreating(modelBuilder);

        //}  //code for addition of dummydata manually

        DbSet<City> Cities { get; set; }
        DbSet<PlaceToVisit> PlacesToVisit { get; set; }

    }
}
