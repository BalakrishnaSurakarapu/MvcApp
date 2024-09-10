using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Orders")]
        public int Orders { get; set; }
        [DisplayName("Amount")]
        public int Amount { get; set; }
    }
}
