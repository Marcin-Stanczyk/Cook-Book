using AutoMapper;
using CookBook.Dtos;
using CookBook.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CookBook.Controllers.API
{
    [AllowAnonymous]
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db;

        public ProductsController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/products
        public IHttpActionResult GetProducts()
        {
            return Ok(db.Products
                .Include(p => p.Category)
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>));
        }

        // GET /api/products/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = db.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        // POST /api/products
        [HttpPost]
        //[Authorize(Roles = RoleName.CanManageProducts)]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);
            db.Products.Add(product);
            db.SaveChanges();

            productDto.Id = product.Id;

            return Created(new Uri(Request.RequestUri + "/" + product.Id), product);
        }

        // PUT /api/products/1
        [HttpPut]
        //[Authorize(Roles = RoleName.CanManageProducts)]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = db.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDto, productInDb);

            db.SaveChanges();

            return Ok();

        }

        // DELETE /api/products/1
        [HttpDelete]
        //[Authorize(Roles = RoleName.CanManageProducts)]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = db.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                return NotFound();

            db.Products.Remove(productInDb);
            db.SaveChanges();

            return Ok();
        }

    }

}
