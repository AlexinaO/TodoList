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

        public IHttpActionResult GetCategorie(int id)
        {
            var categorie = db.Categories.Find(id);
            if (categorie == null)
                return NotFound();

            return Ok(categorie);
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

        public IHttpActionResult PutCategories(int id, Categorie categorie)
        {
            if (id != categorie.ID)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (db.Categories.Count(x => x.ID == id) !=1)
                return BadRequest();

            db.Entry(categorie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent); // renvoyer un code status donc erreur 204 pour dire bien passé mais rien à re
        }

        public IHttpActionResult DeleteCategories(int id)
        {
            var categorie = db.Categories.Find(id);
            if (categorie== null)
                return NotFound();
            if (db.Taches.Count(x => x.CategoryID ==id) != 0)
                return BadRequest("Impossible de supprimer parce que la catégorie est associée à une tâche");

            db.Entry(categorie).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return Ok(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }
    }
}
