using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDomain.Common;
using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppBLL.IServices
{
    public interface IMovieService
    {
        public Task<ServiceResult<Movie>> AddMovie(MovieModel movie);
        public Task<ServiceResult<Movie>> GetMovieById(Guid movieId);
        public Task<ServiceResult<List<Movie>>> GetAllMovies();
    }
}
