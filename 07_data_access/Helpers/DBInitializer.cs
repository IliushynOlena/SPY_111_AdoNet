using _06_02_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _06_02_EntityFramework.Helpers
{
    public static class DBInitializer
    {
        public static  void SeedAirplanes(this ModelBuilder modelBuilder)
        {
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
        }
        public static void SeedFligth(this ModelBuilder modelBuilder)
        {
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
        }
    }
}
