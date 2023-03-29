using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public abstract class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}