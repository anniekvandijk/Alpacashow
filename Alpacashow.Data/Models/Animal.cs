using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alpacashow.Data.Models.Enums;

namespace Alpacashow.Data.Models
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
        public int BreedId { get; set; }
        public int SexId { get; set; }
        public int ColorId { get; set; }
        public int OwnerId { get; set; }

        // Navigation
        public virtual Breed Breed { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual Color Color { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<ShowEventAnimal> ShowEventAnimal { get; set; }

    }
}
