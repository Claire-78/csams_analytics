using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSAMS.Models
{
    public class Users
    {
        [Key]
        [MaxLength(11)]
        public int ID { get; set; }
        [MaxLength(11)]
        [ForeignKey("UserRole")]
        public int Role { get; set; }
        public Roles UserRole { get; set; }
    }
}
