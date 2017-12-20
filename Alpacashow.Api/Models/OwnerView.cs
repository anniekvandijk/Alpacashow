using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpacashow.Api.Models
{
    public class OwnerView
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string FarmName { get; set; }
    }
}
