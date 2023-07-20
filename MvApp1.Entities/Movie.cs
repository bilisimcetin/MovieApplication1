using MovieApplication.Entities;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvApp1.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } 


        public string Description { get; set; } 


        public bool IsWatched { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();



    }
}
