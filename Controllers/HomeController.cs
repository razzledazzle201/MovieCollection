using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDbContext _context;

        private IMovieRepository _repository;

        public static int MovieStaticID;

        public HomeController(ILogger<HomeController> logger, MovieDbContext context, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovie addMovie)
        {

            if (ModelState.IsValid)
            {
                _context.AddMovie.Add(addMovie);
                _context.SaveChanges();
                return View("Database", _context.AddMovie);
            }

            return View("AddMovie");
        }

        [HttpPost]
        public IActionResult EditMovie(int id)
        {
            MovieStaticID = id;
            return View("EditMovie", new MovieViewModel
            {
                AddMovieModel = _context.AddMovie.Single(x => x.MovieID == MovieStaticID),
                ID = MovieStaticID
            });
        }

        public ViewResult Database()
        {
            return View(_context.AddMovie);
        }

        [HttpPost]
        public IActionResult UpdateMovies(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = _context.AddMovie.Single(x => x.MovieID == MovieStaticID);
                _context.Entry(movie).Property(x => x.Category).CurrentValue = model.AddMovieModel.Category;
                _context.Entry(movie).Property(x => x.Title).CurrentValue = model.AddMovieModel.Title;
                _context.Entry(movie).Property(x => x.Year).CurrentValue = model.AddMovieModel.Year;
                _context.Entry(movie).Property(x => x.Director).CurrentValue = model.AddMovieModel.Director;
                _context.Entry(movie).Property(x => x.Rating).CurrentValue = model.AddMovieModel.Rating;
                _context.Entry(movie).Property(x => x.Edited).CurrentValue = model.AddMovieModel.Edited;
                _context.Entry(movie).Property(x => x.LentTo).CurrentValue = model.AddMovieModel.LentTo;
                _context.Entry(movie).Property(x => x.Notes).CurrentValue = model.AddMovieModel.Notes;
                _context.SaveChanges();
                return RedirectToAction("Database");
            }
            else
            {
                return View(new MovieViewModel
                {
                    AddMovieModel = _context.AddMovie.Single(x => x.MovieID == MovieStaticID),
                    ID = MovieStaticID
                });
            }
        }

        public IActionResult DeleteMovies(int id)
        {
            _context.Remove(_context.AddMovie.Single(x => x.MovieID == id));
            _context.SaveChanges();
            return RedirectToAction("Database");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
};