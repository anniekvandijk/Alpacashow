using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alpacashow.Data.Models.Enums;

namespace Alpacashow.Data.Models
{
    public class ShowEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowEventId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(100)]
        public string Judge { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        public bool Archived { get; set; }
        public ShowType ShowType { get; set; }
        public virtual ICollection<ShowEventAnimal> ShowEventAnimal { get; set; }

    }
}
