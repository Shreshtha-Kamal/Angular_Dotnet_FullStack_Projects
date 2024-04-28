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
    public interface IShowService
    {
        public Task<ServiceResult> AddShowForMovie(AddMovieShowModel showData);
        public Task<ServiceResult<List<MovieShow>>> GetAllAvailableMovieShows();
        public Task<ServiceResult<List<MovieShow>>> GetAllFilteredAvailableMovieShows(DateTime filterDate);
    }
}
