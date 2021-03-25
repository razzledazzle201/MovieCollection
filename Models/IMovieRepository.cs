using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public interface IMovieRepository //interface is used for inheritance unlike a class - defines structure
    {
        IQueryable<AddMovie> AddMovie { get; }
    }
}