using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alpacashow.Data.Models.Enums;
using Newtonsoft.Json;

namespace Alpacashow.Data.Models
{
    public class HaltershowAnimal : Animal
    {
        public virtual HaltershowEvent HaltershowEvent { get; set; }
    }
}
