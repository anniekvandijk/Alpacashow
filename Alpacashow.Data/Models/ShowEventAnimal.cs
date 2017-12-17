using Newtonsoft.Json;

namespace Alpacashow.Data.Models
{
    public class ShowEventAnimal
    {
        public int ShowEventId { get; set; }
        public int AnimalId { get; set; }
        
        // Navigation
        [JsonIgnore]
        public virtual ShowEvent ShowEvent { get; set; }
        [JsonIgnore]
        public virtual Animal Animal { get; set; }
    }
}
