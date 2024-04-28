using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDAL.IRepository
{
    public interface IMovieRepository
    {
        public Task<Movie?> GetMovieByMovieName(string movieName);
        public Task<Movie?> GetMovieById(Guid movieId);
        public Task<Movie> AddMovie(Movie movie);
        public Task<List<Movie>> GetAllMovies();
    }
}
