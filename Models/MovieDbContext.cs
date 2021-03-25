using System;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Models
{
    public class MovieDbContext : DbContext // inherit from DbContext & using Microsoft.EntityFrameworkCore; above
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options) : base(options)
        {// Constructor recieves DbContextOptions of type OnlineBookStoreDbContext called options that inherits from base of DbContext

        }

        public DbSet<AddMovie> AddMovie { get; set; } // used to query and save instances of BookModel
    }
}