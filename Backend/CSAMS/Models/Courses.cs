using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSAMS.Models
{
    public enum SemesterSeasons
    {
        Fall,
        Spring
    }

    public class Courses
    {
        [Key]
        [MaxLength(11)]
        public int ID { get; set; }
        [MaxLength(64)]
        [Column(TypeName = "VARCHAR")]
        public string Hash { get; set; }
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        public string CourseCode { get; set; }
        [MaxLength(64)]
        [Column(TypeName = "VARCHAR")]
        public string CourseName { get; set; }
        [MaxLength(11)]
        [ForeignKey("User")]
        public int Teacher { get; set; }
        public Users User { get; set; }
        public string Description { get; set; }
        [MaxLength(11)]
        public int Year { get; set; }
        public SemesterSeasons Semester { get; set; }

    }
}
