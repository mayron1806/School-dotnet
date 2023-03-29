using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ClassroomID { get; set; }
    } 
}