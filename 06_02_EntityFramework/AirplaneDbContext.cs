

using _06_02_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace _06_02_EntityFramework
{
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
                                            Connect Timeout=2;
                                            Encrypt=False;
                                            TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //initialization
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane()
                {
                     Id = 1, Model = "Boeing 727", MaxPassangers = 120
                },
                new Airplane()
                {
                     Id = 2, Model = "Am 727", MaxPassangers = 90
                }
            });
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                     Number = 1,
                     ArrivelTime = new DateTime(2023,3,20),
                     DepartureTime = new DateTime(2023,3,20),
                     ArrivelCity = "Lviv",
                     DepartureCity = "Kyiv",
                     AirplaneId = 1

                },
                new Flight()
                {
                      Number = 2,
                      ArrivelTime = new DateTime(2023,3,20),
                      DepartureTime = new DateTime(2023,3,20),
                      ArrivelCity = "Lviv",
                      DepartureCity = "Warshaw",
                      AirplaneId = 2
                }
            });

            //Fluent API configurations
            modelBuilder.Entity<Airplane>().Property(a => a.Model).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Client>().ToTable("Passengers");
            modelBuilder.Entity<Client>()
                .Property(c=>c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");
            modelBuilder.Entity<Client>().Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Flight>().HasKey(f => f.Number);//set primary key
            modelBuilder.Entity<Flight>().Property(f=>f.ArrivelCity)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Flight>().Property(f => f.DepartureCity)
              .IsRequired()
              .HasMaxLength(100);
            //Relationship configurations
            modelBuilder.Entity<Client>().HasMany(c=>c.Flights).WithMany(f=>f.Clients);//or
            //modelBuilder.Entity<Flight>().HasMany(f => f.Clients).WithMany(c => c.Flights);

            modelBuilder.Entity<Airplane>()
                .HasMany(a => a.Flights)
                .WithOne(f => f.Airplane)
                .HasForeignKey(f=>f.AirplaneId);
        }
    }
}
