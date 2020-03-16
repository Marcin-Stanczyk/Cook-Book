using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CookBook.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public bool InStock { get; set; }
    }
}