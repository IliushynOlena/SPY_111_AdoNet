using System;
using System.Data.SqlClient;
using System.Text;

namespace _06_IntroToEntityFramework
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

            foreach (var c in context.Clients)
            {
                Console.WriteLine($"Client : {c.Name}  {c.Email}  {c.Birthdate.ToShortDateString()}");
            }

        }
    }
}
