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

        DbSet<City> Cities { get; set; }
        DbSet<PlaceToVisit> PlacesToVisit { get; set; }

    }
}
