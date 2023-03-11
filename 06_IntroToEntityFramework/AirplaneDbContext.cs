using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_IntroToEntityFramework
{
    //Entities
    public class Client
    {
        //Primary Key naming : Id/id/ID / EntityName + Id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> Flights { get; set; }

    }
    public class Flight
    {
        public int Id { get; set; }
        public DateTime ArrivelTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivelCity { get; set; }
        public string DepartureCity { get; set; }
        // ForeignKey namig: RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }//foreign key

        //Navigation property
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
    public class AirplaneDbContext : DbContext
    {
        //Collection
        //Clients
        //Aiplanes
        //Fligths
        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();  
            //this.Database.EnsureCreated();  
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                            Initial Catalog = DataBaseNew;
                                            Integrated Security=True;
                                            Connect Timeout=30;
                                            Encrypt=False;
                                            TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite
                                            ;MultiSubnetFailover=False");

        }
    }
}
