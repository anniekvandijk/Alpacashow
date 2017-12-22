using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alpacashow.Data.Models.Enums;
using Newtonsoft.Json;

namespace Alpacashow.Data.Models
{
    public class Animal
    {
        [Key]
        [ReadOnly(true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        public string FarmName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Chip { get; set; }
        [Required]
        [MaxLength(100)]
        public string Sire { get; set; }
        [Required]
        [MaxLength(100)]
        public string Dam { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        public DateTime SheerDate { get; set; }
        public DateTime BeforeSheerDate { get; set; }
        [Required]
        public virtual Breed Breed { get; set; }
        [Required]
        public virtual Sex Sex { get; set; }
        [Required]
        public virtual Color Color { get; set; }
        public virtual ShowEvent ShowEvent { get; set; }
    }
}
