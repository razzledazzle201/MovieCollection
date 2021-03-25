using System;
using System.Linq;

namespace MovieCollection.Models
{
    public class EFMovieRepository : IMovieRepository // here is where we implement (use the template) 
    {
        private MovieDbContext _context; // private BookstoreDbContext type called context _ means private

        public EFMovieRepository(MovieDbContext context) // Constructor
        {
            _context = context;
        }
        public IQueryable<AddMovie> AddMovie => _context.AddMovie;
    }
}