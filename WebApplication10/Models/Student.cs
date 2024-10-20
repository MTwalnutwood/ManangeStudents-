using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
namespace WebApplication10.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please enter a valid name (letters only).")]
        public string Name { get; set; }
        [Range(0, 20, ErrorMessage = "Physics grade must be between 0 and 20.")]
        public double PhysicsGrade { get; set; }
        [Range(0, 20, ErrorMessage = "Mathematics grade must be between 0 and 20.")]
        public double MathematicsGrade { get; set; }
        [Range(0, 20, ErrorMessage = "Science must be between 0 and 20.")]
        public double Science { get; set; }

        public double CalculateAverage()
        {
            double average = (PhysicsGrade + MathematicsGrade + Science) / 3.0;
            return Math.Round(average, 2);  
        }

    }
}
