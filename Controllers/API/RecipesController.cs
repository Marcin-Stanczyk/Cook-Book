using CookBook.Dtos;
using CookBook.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Newtonsoft.Json;
using CookBook.ViewModels;

namespace CookBook.Controllers.API
{
    [AllowAnonymous]
    public class RecipesController : ApiController
    {
        private ApplicationDbContext db;

        public RecipesController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/recipes
        public IHttpActionResult GetRecipes()
        {
            return Ok(db.Recipes.ToList());
        }


        // GET /api/recipes/1
        public IHttpActionResult GetRecipe(int id)
        {

            
            var recipe = db.Recipes.SingleOrDefault(r => r.Id == id);
            
            if (recipe == null)
                return NotFound();

            var ingredients = db.Ingredients
                .Include(i => i.Unit)
                .Include(i => i.Product)
                .Where(i => i.Recipe.Id == recipe.Id).ToList();


            var products = new List<Product>();
            var units = new List<Unit>();
            var amounts = new List<float>();

            foreach(var ingredient in ingredients)
            {
                products.Add(ingredient.Product);
                units.Add(ingredient.Unit);
                amounts.Add(ingredient.Amount);
            }

            var recipeViewModel = new RecipeViewModel()
            {
                Recipe = recipe,
                Products = products,
                Units = units,
                Amounts = amounts
            };


            return Ok(recipeViewModel);
        }

        // POST /api/recipes
        [HttpPost]
        public IHttpActionResult CreateRecipe(RecipeDto recipeDto)
        {
            var recipe = new Recipe();
            recipe.Name = recipeDto.Name;
            recipe.Description = recipeDto.Description;
            recipe.InstructionSteps = recipeDto.InstructionSteps;
            

            db.Recipes.Add(recipe);

            

            var products = db.Products.Where(p => recipeDto.ProductIds.Contains(p.Id)).ToList();
            var units = db.Units.Where(u => recipeDto.UnitIds.Contains(u.Id)).ToList();
            var amounts = recipeDto.Amounts;

            for (int i=0; i<products.Count; i++)
            {
                var ingredient = new Ingredient()
                {
                    Product = products[i],
                    Unit = units[i],
                    Amount = amounts[i],
                    Recipe = recipe
                };


                db.Ingredients.Add(ingredient);
            }

            
            db.SaveChanges();

            return Ok();
        }
    }
}
