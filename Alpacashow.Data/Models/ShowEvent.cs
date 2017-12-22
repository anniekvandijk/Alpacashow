using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Alpacashow.Data.Models.Enums;
using Newtonsoft.Json;

namespace Alpacashow.Data.Models
{
    public class ShowEvent
    {
        [Key]
        [ReadOnly(true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowEventId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(100)]
        public string Judge { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        [DefaultValue(false)]
        public bool Archived { get; set; }
        [Required]
        public virtual ShowType ShowType { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }

    }
}
