using CookBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookBook.Dtos
{
    public class RecipeDto
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string InstructionSteps { get; set; }

        public List<int> ProductIds { get; set; }

        public List<int> UnitIds { get; set; }

        public List<int> Amounts { get; set; }

    }
}