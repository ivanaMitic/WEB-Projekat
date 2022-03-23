using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Plesni Klub")]
    public class PlesniKlub
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public List<ClanKluba> ClanoviKluba {get; set; }
        public List<Ples> Plesovi {get; set; }
        public List<Placanje> Placanja {get; set; }
    }
}