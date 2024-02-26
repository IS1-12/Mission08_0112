using System.ComponentModel.DataAnnotations;

namespace Putting_Things_First_1_12.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
