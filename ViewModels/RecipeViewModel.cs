using CookBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookBook.ViewModels
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }

        public List<Product> Products { get; set; }

        public List<Unit> Units { get; set; }

        public List<float> Amounts { get; set; }

        public List<string> Instructions { get; set; }

        public void CutInstructions()
        {
            Instructions = Recipe.InstructionSteps.Split('X').ToList();
            Instructions.RemoveAt(Instructions.Count - 1);
            
        }
    }
}