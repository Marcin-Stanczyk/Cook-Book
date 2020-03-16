using CookBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CookBook.Controllers.API
{
    [AllowAnonymous]
    public class UnitsController : ApiController
    {
        private ApplicationDbContext db;

        public UnitsController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/units
        public IHttpActionResult GetUnits()
        {
            return Ok(db.Units.ToList());
        }
    }
}
