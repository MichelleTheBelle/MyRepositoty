using System.ComponentModel.DataAnnotations;

namespace George_Petrov_Kt_43_21.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; } 
        public string? LastName { get; set; } 
        public string? FirstName { get; set; } 
        public string? Patronymic { get; set; } 

        public int DegreeId { get; set; }
        public Degree? Degree { get; set; }

        public int PositionId { get; set; }
        public Position? Position { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
