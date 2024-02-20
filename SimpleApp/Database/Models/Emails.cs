using SimpleApp.Database.Configuration.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApp.Database.Models
{
    public class Emails : BaseEntity<int>
    {
        public Emails()
        {
        }

        public Emails(string Email)
        {
            Email = Email;
        }

        [Column("Email")]
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("PersonId")]
        [Required]
        public int PersonId { get; set; }

        //Entity connection
        public Persons Person { get; set; }

    }
}
