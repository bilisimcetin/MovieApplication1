﻿using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Entities
{
    public class WatchedMovie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
