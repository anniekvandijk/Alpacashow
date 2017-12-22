using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alpacashow.Data.Models
{
    public class MaleProgeny
    {
        [Key]
        [ReadOnly(true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaleProgenyId { get; set; }
        public virtual Animal Animal1 { get; set; }
        public virtual Animal Animal2 { get; set; }
        public virtual Animal Animal3 { get; set; }
    }
}
