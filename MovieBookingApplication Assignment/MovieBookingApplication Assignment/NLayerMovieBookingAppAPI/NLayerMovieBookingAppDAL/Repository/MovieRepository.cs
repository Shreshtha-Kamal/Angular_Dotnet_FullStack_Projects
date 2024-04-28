using Microsoft.EntityFrameworkCore;
using NLayerMovieBookingAppDAL.DB;
using NLayerMovieBookingAppDAL.IRepository;
using NLayerMovieBookingAppDomain.Common;
using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDAL.Repository
{
    public class MovieRepository: IMovieRepository
    {
        private readonly AppDBContext _appDBContext;

        public MovieRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<Movie?>GetMovieByMovieName(string movieName)
        {
            try
            {
                var movie= await _appDBContext.Movies.FirstOrDefaultAsync(m=>m.Name == movieName);
                return movie;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<Movie?>GetMovieById(Guid movieId)
        {
            try
            {
                //var movie = await _appDBContext.Movies.FirstOrDefaultAsync(m => m.MovieId == movieId);
                var movie = await _appDBContext.Movies.Where(m => m.MovieId == movieId).Include(m=>m.MovieShow).FirstOrDefaultAsync();
                return movie;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            try
            {
                var newMovie = await _appDBContext.Movies.AddAsync(movie);
                await _appDBContext.SaveChangesAsync();
                return newMovie.Entity;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<List<Movie>> GetAllMovies()
        {
            try
            {
                var movies= await _appDBContext.Movies.Include(m=>m.MovieShow).ToListAsync();
                return movies;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
