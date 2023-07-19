using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Entities
{
    
    public class MovieCreateDTO
    {


           
           public string Name { get; set; }
           public string Description { get; set; }
           public bool IsWatched { get; set; }

           public List<int> CategoryIds { get; set; }
    }

   
}
