using NLayerMovieBookingAppBLL.IServices;
using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDAL.IRepository;
using NLayerMovieBookingAppDomain.Common;
using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppBLL.Services
{
    public class ShowService: IShowService
    {
        private readonly IShowRepository _showRepository;
        private readonly IMovieRepository _movieRepository;
        public ShowService(IShowRepository showRepository, IMovieRepository movieRepository)
        {
            _showRepository = showRepository;
            _movieRepository = movieRepository;

        }

        public async Task<ServiceResult>AddShowForMovie(AddMovieShowModel showData)
        {
            try
            {
                var showMovie = await _movieRepository.GetMovieById(showData.MovieId);
                if (showMovie == null)
                {
                    return new ServiceResult(HttpStatusCode.NotFound, "Movie with the Given MovieId Doesnot Exist");
                }
                if(showMovie.MovieLengthInMinutes >= ((showData.EndTime - showData.StartTime).TotalMinutes + 15)|| showMovie.IsShowAdded)
                {
                    return new ServiceResult(HttpStatusCode.NotAcceptable, "Show Timings are not as per the movie length or show already added for movie");
                }
                var isSlotAvailable= await _showRepository.IsShowSlotAvailable(showData.ScreenId, showData.StartDate, showData.EndDate, showData.StartTime, showData.EndTime);
                if (isSlotAvailable)
                {
                    var showEntity = new MovieShow()
                    {
                        ShowId= Guid.NewGuid(),
                        StartDate= showData.StartDate,
                        EndDate= showData.EndDate,
                        StartTime= showData.StartTime,
                        EndTime= showData.EndTime,
                        TotalSeats= showData.TotalSeats,
                        Price= showData.Price,
                        ScreenId= showData.ScreenId,
                        MovieId= showData.MovieId,
                        SeatsRemaining= showData.TotalSeats
                    };
                    var result= await _showRepository.AddMovieShow(showEntity)?? throw new ApiException(HttpStatusCode.InternalServerError, new Exception("Show Creation for movie failed"));
                    return new ServiceResult(HttpStatusCode.Created, "Show Added Successfully for the Movie");
                }
                return new ServiceResult(HttpStatusCode.Conflict, "Conflicted Show Timing");
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

        public async Task<ServiceResult<List<MovieShow>>> GetAllAvailableMovieShows()
        {
            try
            {
                var today = DateTime.Today;
                var shows = await _showRepository.GetAllAvailableShow(today);
                if (shows==null)
                {
                    var showsData= new List<MovieShow>();
                    return new ServiceResult<List<MovieShow>>(HttpStatusCode.OK, showsData);
                }
                return new ServiceResult<List<MovieShow>>(HttpStatusCode.OK, shows);
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

        public async Task<ServiceResult<List<MovieShow>>> GetAllFilteredAvailableMovieShows(DateTime filterDate)
        {
            try
            {
                var shows = await _showRepository.GetAllAvailableShow(filterDate);
                if (shows == null)
                {
                    var showsData = new List<MovieShow>();
                    return new ServiceResult<List<MovieShow>>(HttpStatusCode.OK, showsData);
                }
                return new ServiceResult<List<MovieShow>>(HttpStatusCode.OK, shows);
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
