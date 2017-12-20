using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Alpacashow.Data.Models.Enums;
using Newtonsoft.Json;

namespace Alpacashow.Api.Models
{
    public class ShowEventView
    {
        public int ShowEventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Judge { get; set; }
        public string Location { get; set; }
        public bool Archived { get; set; }
        public string ShowType { get; set; }
        public List<AnimalView> Animals { get; set; }

    }
}
