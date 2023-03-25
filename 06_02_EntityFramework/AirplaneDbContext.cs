

using _06_02_EntityFramework.Entities;
using _06_02_EntityFramework.Helpers;
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

            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFligth();

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
