using CookBook.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CookBook.ViewModels;

namespace CookBook.Controllers
{
    [AllowAnonymous]
    public class RecipesController : Controller
    {
        private ApplicationDbContext db;

        public RecipesController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Recipes
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult Details(int id)
        {

            var recipe = db.Recipes.SingleOrDefault(r => r.Id == id);
            if (recipe == null)
                return HttpNotFound();

            var ingredients = db.Ingredients
                .Include(i => i.Unit)
                .Include(i => i.Product)
                .Where(i => i.Recipe.Id == recipe.Id).ToList();


            var products = new List<Product>();
            var units = new List<Unit>();
            var amounts = new List<float>();

            foreach (var ingredient in ingredients)
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

            recipeViewModel.CutInstructions();

            return View(recipeViewModel);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}