

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _06_02_EntityFramework.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> Flights { get; set; }

    }
}
