using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpacashow.Models
{
    public class ShowEventAnimal
    {
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public int ShowEventId { get; set; }
        public ShowEvent ShowEvent { get; set; }
    }
}
