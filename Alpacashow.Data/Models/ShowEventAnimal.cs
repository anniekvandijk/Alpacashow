using System;
using System.ComponentModel.DataAnnotations;
using Alpacashow.Data.Models.Enums;
using Newtonsoft.Json;

namespace Alpacashow.Data.Models
{
    public class ShowEventAnimal
    {
        [Required]
        public int ShowEventId { get; set; }
        [Required]
        public int AnimalId { get; set; }
        public virtual ShowEvent ShowEvent { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
