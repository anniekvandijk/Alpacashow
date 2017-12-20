using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alpacashow.Data.Models.Enums;
using Newtonsoft.Json;

namespace Alpacashow.Data.Models
{
    public class AnimalOwner
    {
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
