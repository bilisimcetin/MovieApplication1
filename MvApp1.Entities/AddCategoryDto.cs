using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvApp1.Entities;

namespace MovieApplication.Entities
{
    public class AddCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
