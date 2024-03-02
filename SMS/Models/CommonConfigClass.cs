using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class CommonConfigClass
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
