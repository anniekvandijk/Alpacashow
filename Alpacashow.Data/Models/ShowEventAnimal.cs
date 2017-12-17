namespace Alpacashow.Data.Models
{
    public class ShowEventAnimal
    {
        public int ShowEventId { get; set; }
        public int AnimalId { get; set; }
        public virtual ShowEvent ShowEvent { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
