using ApplicationCore.Entities;
using ApplicationCore.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;
        public MovieRepository(MovieShopDbContext dbContext)
        {
            _movieShopDbContext = dbContext;
        }
        public Movie GetById(int id)
        {
            // select * from movie where id = 1 join genre, cast, moviegerne, moviecast
            var movieDetails = _movieShopDbContext.Movies
                .Include(m => m.GenresOfMovie).ThenInclude(m => m.Genre)
                .Include(m => m.CastsOfMovie).ThenInclude(m => m.Cast)
                .Include(m => m.Trailers)
                .FirstOrDefault(m => m.Id == id);
            return movieDetails;
        }

        public List<Movie> GetTop30HighestRevenueMovies()
        {
            // Go to Database and get the top movies
            // EF Core or Dapper to connect to database

            //var movies = new List<Movie>
            //{
            //              new Movie {Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
            //              new Movie {Id = 2, Title = "Avatar", Budget = 1200000},
            //              new Movie {Id = 3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
            //              new Movie {Id = 4, Title = "Titanic", Budget = 1200000},
            //              new Movie {Id = 5, Title = "Inception", Budget = 1200000},
            //              new Movie {Id = 6, Title = "Avengers: Age of Ultron", Budget = 1200000},
            //              new Movie {Id = 7, Title = "Interstellar", Budget = 1200000},
            //              new Movie {Id = 8, Title = "Fight Club", Budget = 1200000},
            //              new Movie
            //              {
            //                  Id = 9, Title = "The Lord of the Rings: The Fellowship of the Ring", Budget = 1200000
            //              },
            //              new Movie {Id = 10, Title = "The Dark Knight", Budget = 1200000},
            //              new Movie {Id = 11, Title = "The Hunger Games", Budget = 1200000},
            //              new Movie {Id = 12, Title = "Django Unchained", Budget = 1200000},
            //              new Movie
            //              {
            //                  Id = 13, Title = "The Lord of the Rings: The Return of the King", Budget = 1200000
            //              },
            //              new Movie {Id = 14, Title = "Harry Potter and the Philosopher's Stone", Budget = 1200000},
            //              new Movie {Id = 15, Title = "Iron Man", Budget = 1200000},
            //              new Movie {Id = 16, Title = "Furious 7", Budget = 1200000}
            //};

            //return movies;

            var movies =  _movieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }

        public List<Movie> GetTop30RatedMovies()
        {
            throw new NotImplementedException();
        }
    }
}
