using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Putting_Things_First_1_12.Models
{
    public class TaskEntry
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string TaskTitle { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool Completed { get; set; }
    }
}
