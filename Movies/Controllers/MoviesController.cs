using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Models;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public MoviesController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        public IActionResult Index()
        {
            return View(dbcontext.Movies);
        }

        public IActionResult Create()
        {
           return View();
        }

        [HttpPost()]
        public IActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            dbcontext.Movies.Add(movie);
            dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public string VerySimple(int x, int y)
        {
            return $"My Simple Very Controller {x + y}";
            // zapytanie postman: localhost:44354/simple/VerySimple/?x=5&y=6
        }
    }
}