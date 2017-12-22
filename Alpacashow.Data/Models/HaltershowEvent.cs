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
    public class HaltershowEvent : ShowEvent
    {
        public virtual ICollection<HaltershowAnimal> HaltershowAnimals { get; set; }
        public virtual HaltershowOrder HaltershowOrder { get; set; }
        public virtual ICollection<MaleProgeny> MaleProgenys { get; set; }
        public virtual ICollection<FemaleProgeny> FemaleProgenys { get; set; }
    }
}
