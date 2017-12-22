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
    public class FleeceshowEvent : ShowEvent
    {
        public virtual ICollection<FleeceshowAnimal> FleeceshowAnimals { get; set; }
        public virtual FleeceshowOrder FleeceshowOrder { get; set; }
    }
}
