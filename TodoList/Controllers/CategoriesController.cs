using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class CategoriesController : ApiController
    {
        private TodoDbContext db = new TodoDbContext();

        public IQueryable<Categorie> GetCategories()
        {
            return db.Categories.OrderBy(x => x.Nom);
        }

        public IHttpActionResult PostCategories(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categorie);
                db.SaveChanges();

                return Ok(categorie);
            }
            else
                return BadRequest(ModelState);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }
    }
}
