using System.ComponentModel.DataAnnotations;

namespace George_Petrov_Kt_43_21.Models
{
    public class Subject
    {
        public int SubjectId { get; set; } 

        public string? Name { get; set; } 

        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int TeachingLoadId { get; set; }
        public TeachingLoad? TeachingLoad { get; set; }
    }
}
