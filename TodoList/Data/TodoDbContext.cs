using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoDbContext : DbContext

    {
        public TodoDbContext() : base("TodoListConnectionString")
        {
        }

        public DbSet<Categorie> Categories {get;set;}
    }
}