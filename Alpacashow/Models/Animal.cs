using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alpacashow.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Chip { get; set; }
        public string Sire { get; set; }
        public string Dam { get; set; }
        public DateTime Dob { get; set; }
        public Breed Breed { get; set; }
        public Sex Sex { get; set; }
        public Color Color { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<ShowEvent> ShowEventAnimal { get; set; }

    }
}
