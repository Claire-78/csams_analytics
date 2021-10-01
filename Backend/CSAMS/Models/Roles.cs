using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSAMS.Models
{
    public class Roles
    {
        [Key]
        [MaxLength(11)]
        public int ID { get; set; }
        [MaxLength(256)]
        [Column(TypeName = "VARCHAR")]
        public string Key { get; set; }
        [MaxLength(256)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
    }
}
