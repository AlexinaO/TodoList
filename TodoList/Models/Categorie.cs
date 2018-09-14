using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        //[DisplayColumn("Name")]
        public string Nom { get; set; }
    }
}