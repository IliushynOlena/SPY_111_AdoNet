using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _06_02_EntityFramework.Entities
{
    public class Flight
    {
        [Key]//set primary key
        public int Number { get; set; }
        public DateTime ArrivelTime { get; set; }
        public DateTime DepartureTime { get; set; }
        [Required, MaxLength(100)]
        public string ArrivelCity { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        // ForeignKey namig: RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }//foreign key

        //Navigation property
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
