using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Clanarina")]
    public class Clanarina
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string Mesec { get; set; }

        [Required]
        [Range(2014, 2022)]
        public int Godina { get; set; }

        [JsonIgnore]
        public List<Placanje> ClanoviPlesovi {get; set; }
    }
}