using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie: Entity
    {
        public string Title { get; set; }
        public string Lenght { get; set; }
    }
}
