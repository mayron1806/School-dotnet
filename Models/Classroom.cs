using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class Classroom: BaseModel
    {

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }
        
        public List<Student> students { get; set; }
    }
}
