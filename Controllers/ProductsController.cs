using CookBook.Models;
using CookBook.ViewModels;
using System;
using System.IO;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace CookBook.Controllers
{
    [AllowAnonymous]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Products
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageProducts))
                return View("List");

            return View("ReadOnlyList");
        }


        //[Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult New()
        {

            var categories = _context.Categories.ToList();
            var productFormViewModel = new ProductFormViewModel()
            {
                Categories = categories,
                Product = new Product()
            };
            return View("ProductForm", productFormViewModel);
        }

        //[Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            var productFormView = new ProductFormViewModel
            {
                Product = product,
                Categories = _context.Categories.ToList()
            };

            return View("ProductForm", productFormView);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult Save(ProductFormViewModel productForm)
        {

            if (!ModelState.IsValid)
            {
                var productViewModel = new ProductFormViewModel()
                {
                    Product = productForm.Product,
                    Categories = _context.Categories.ToList(),
                    File = productForm.File
                };

                return View("ProductForm", productViewModel);
            }

            var product = productForm.Product;

            if (productForm.File != null)
            {
                var fileName = Path.GetFileName(productForm.File.FileName);
                var directoryPath = "/images/products/" + product.CategoryId.ToString() + "/";
                var path = directoryPath + fileName;
                product.PhotoPath = path;

                var serverPath = Server.MapPath(path);
                if (!System.IO.File.Exists(serverPath))
                    productForm.File.SaveAs(serverPath);
            }


            if (product.Id == 0)
            {
                _context.Products.Add(product);

            }

            else
            {
                var productInDb = _context.Products.SingleOrDefault(p => p.Id == product.Id);

                productInDb.Name = product.Name;
                productInDb.PhotoPath = product.PhotoPath;
                productInDb.InStock = product.InStock;
                productInDb.CategoryId = product.CategoryId;
            }


            _context.SaveChanges();
            

            return RedirectToAction("Index", "Products");
        }
    }
}