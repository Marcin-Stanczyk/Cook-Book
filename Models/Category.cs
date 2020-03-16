using System.ComponentModel.DataAnnotations;

namespace CookBook.Models
{
    public class Category
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
    }
}