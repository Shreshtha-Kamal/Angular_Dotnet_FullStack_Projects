using NLayerMovieBookingAppBLL.IServices;
using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDAL.IRepository;
using NLayerMovieBookingAppDomain.Common;
using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppBLL.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ServiceResult<Movie>>AddMovie(MovieModel movie)
        {
            try
            {
                var existingMovie= await _movieRepository.GetMovieByMovieName(movie.Name);
                if (existingMovie != null)
                {
                    return new ServiceResult<Movie>(HttpStatusCode.Conflict, new ValidationError(code: "Movie Addition Failed", description: "Movie Already Added in DB"));
                }
                var movieEntity = new Movie()
                {
                    MovieId= Guid.NewGuid(),
                    Name = movie.Name,
                    Genre = movie.Genre,
                    DirectorName = movie.DirectorName,
                    Description = movie.Description,
                    BannerImageUrl = movie.BannerImageUrl,
                    MovieLengthInMinutes = movie.MovieLengthInMinutes,
                    IsShowAdded= false
                };
                var addedMovie= await _movieRepository.AddMovie(movieEntity)?? throw new ApiException(HttpStatusCode.InternalServerError,new Exception("Movie Addition Failed"));
                return new ServiceResult<Movie>(HttpStatusCode.Created, addedMovie);
            }
            catch (ApiException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<ServiceResult<Movie>>GetMovieById(Guid movieId)
        {
            try
            {
                var movie = await _movieRepository.GetMovieById(movieId);
                if (movie == null)
                {
                    return new ServiceResult<Movie>(HttpStatusCode.NotFound, new ValidationError(code: "MovieNotFound", description: "Movie with this Id doesnot exist"));
                }
                return new ServiceResult<Movie>(HttpStatusCode.OK, movie);
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<ServiceResult<List<Movie>>> GetAllMovies()
        {
            try
            {
                var movies= await _movieRepository.GetAllMovies();
                if (movies == null)
                {
                    var allMovies= new List<Movie>();
                    return new ServiceResult<List<Movie>>(HttpStatusCode.OK, allMovies);
                }
                return new ServiceResult<List<Movie>>(HttpStatusCode.OK, movies);
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
