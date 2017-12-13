using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpacashow.Models
{
    public class ShowEventParticipant
    {
        public int ShowEventId { get; set; }
        public ShowEvent ShowEvent { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

    }
}
