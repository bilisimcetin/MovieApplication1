﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvApp1.Entities;

namespace MvApp1.Entities
{
   public class Category
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public virtual List<Movie> Movies { get; set; } = new List<Movie>();


    }
}
