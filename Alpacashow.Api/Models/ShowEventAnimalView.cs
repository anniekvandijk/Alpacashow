using System;
using System.ComponentModel.DataAnnotations;
using Alpacashow.Data.Models.Enums;
using Newtonsoft.Json;

namespace Alpacashow.Api.Models
{
    public class ShowEventAnimalView
    {
        public int ShowEventId { get; set; }
        public int AnimalId { get; set; }
    }
}
