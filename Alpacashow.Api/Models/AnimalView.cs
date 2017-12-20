using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alpacashow.Data.Models.Enums;
using Newtonsoft.Json;

namespace Alpacashow.Api.Models
{
    public class AnimalView
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Chip { get; set; }
        public string Sire { get; set; }
        public string Dam { get; set; }
        public DateTime Dob { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public string Color { get; set; }
        public OwnerView Owner { get; set; }

    }
}
