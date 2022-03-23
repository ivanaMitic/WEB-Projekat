using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Placanje
    {
        [Key]
        public int ID { get; set; }

        public Clanarina Clanarina {get; set; }

        [JsonIgnore]
        public ClanKluba ClanKluba { get; set; }
        
        public Ples Ples { get; set; }

        [Range(1400, 3700)]
        public int Cena { get; set; }

        public PlesniKlub PlesniKlub { get; set; }
    }
}