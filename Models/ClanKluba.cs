using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Clan Kluba")]
    public class ClanKluba
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int JB {get; set; }

        [Required]
        [MaxLength(25)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(25)]
        public string Prezime { get; set; }

        [Required]
        [DataType(DataType.Date)]/* 
        [RegularExpression("^\\d{4}-((0\\d)|(1[012]))-(([012]\\d)|3[01])$", ErrorMessage = "Datum nije ispravnog formata!")] */
        public string DatumRodjenja { get; set; }

        [Required]
        [MaxLength(10)]
        public string Kategorija { get; set; }

        [JsonIgnore]
         public List<Placanje> ClanPles {get; set; }
         public PlesniKlub PlesniKlub { get; set; }
    }
}