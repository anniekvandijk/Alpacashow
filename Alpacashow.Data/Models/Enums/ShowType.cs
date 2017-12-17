using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpacashow.Data.Models.Enums
{
    public class ShowType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
