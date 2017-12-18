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
        [Required(ErrorMessage = "The field 'Location' is required")]
        [MaxLength(100, ErrorMessage = "The field 'Location' can be max 100 characters")]
        public string Location { get; set; }
        [DefaultValue(false)]
        public bool Archived { get; set; }
        [Required(ErrorMessage = "The field 'ShowTypeId' is required and must be a existing id")]
        public int ShowTypeId { get; set; }
        [JsonIgnore]
        public virtual ShowType ShowType { get; set; }
        [JsonIgnore]
        public virtual ICollection<ShowEventAnimal> ShowEventAnimal { get; set; }

    }
}
