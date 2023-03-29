using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Student: BaseModel
    {
        [Required, MaxLength(100), MinLength(3)]
        public string Name { get; set; }
        public Classroom classroom { get; set; }
    }
}
