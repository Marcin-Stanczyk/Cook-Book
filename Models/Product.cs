using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CookBook.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }

        [Display(Name = "Category")]
        [Required]
        public byte CategoryId { get; set; }

        public Category Category { get; set; }

        public bool InStock { get; set; }

    }
}