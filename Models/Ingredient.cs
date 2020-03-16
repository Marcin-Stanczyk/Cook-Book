using System.ComponentModel.DataAnnotations;

namespace CookBook.Models
{
    public class Ingredient
    {
        [Display(Name = "Ingredient")]
        public int Id { get; set; }

        public Recipe Recipe { get; set; }

        public Product Product { get; set; }

        public Unit Unit { get; set; }

        public float Amount { get; set; }

    }
}