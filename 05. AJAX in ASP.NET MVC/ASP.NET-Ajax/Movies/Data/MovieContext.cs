using Movies.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Movies.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("DefaultConnection")
        { }

        public DbSet<Movie> Movies
        {
            get;
            set;
        }

        public DbSet<Actor> Actors
        {
            get;
            set;
        }

        public System.Data.Entity.DbSet<Movies.ViewModels.MovieViewModel> MovieViewModel { get; set; }
    }
}