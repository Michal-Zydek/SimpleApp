using SimpleApp.Database.Configuration.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApp.Database.Models
{
    [Table("Person")]
    public class Persons : BaseEntity<int>
    {
        public Persons()
        {
        }

        public Persons(string Imie, string Nazwisko, string Opis)
        {
            Imie = Imie;
            Nazwisko = Nazwisko;  
            Opis = Opis;
            Emails = new List<Emails>();
        }

        [Column("Imie")]
        [Required]
        [StringLength(50)]
        public string Imie { get; set; }

        [Column("Nazwisko")]
        [Required]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Column("Opis")]
        public string Opis { get; set; }

        //Entity connection
        public IEnumerable<Emails> Emails { get; set; }
    }
}
