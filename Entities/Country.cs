﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGP.API.Entities
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Rider> Riders { get; set; } = [];
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public Country (string name)
        {
            Name = name;
        }
    }
    
   
}
