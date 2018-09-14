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
            return db.Categories;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }
    }
}
