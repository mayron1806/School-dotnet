using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateClassroomDto
    {
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Type { get; set; }
    } 
}