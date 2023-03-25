using System;
using System.Linq;
using _06_02_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace _06_02_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext context = new AirplaneDbContext();
            context.Clients.Add(new Client
            {
                Name = "Volodia",
                Birthdate = new DateTime(2006, 7, 9),
                Email = "volodia@gmail.com"
            });
            context.SaveChanges();

            //foreach (var c in context.Clients)
            //{
            //    Console.WriteLine($"Client : {c.Name}  {c.Email}  {c.Birthdate}");
            //}

            var res = context.Flights.Include(f=>f.Airplane).Where(f => f.ArrivelCity == "Lviv").OrderBy(f => f.DepartureTime);

            foreach (var f in res)
            {
                Console.WriteLine($"Flight : {f.Number}  {f.DepartureCity}  " +
                    $"{f.ArrivelCity} Id Airplane {f.AirplaneId} Airplane: {f.Airplane?.Model}");
            }
        }
    }
}
