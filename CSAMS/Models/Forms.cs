using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSAMS.Models
{
    public class Forms
    {
        [Key]
        [MaxLength]
        public int ID { get; set; }
        [MaxLength(256)]
        [Column(TypeName = "VARCHAR")]
        public string Prefix { get; set; }
        [MaxLength(256)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
        [Timestamp]
        public byte[] Created { get; set; }
    }
}
