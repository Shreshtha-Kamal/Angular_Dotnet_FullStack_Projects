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
    public class ShowRepository: IShowRepository
    {
        private readonly AppDBContext _appDBContext;
        public ShowRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public bool isShowConflictedByDate(MovieShow show, DateTime upcomingShowStartDate, DateTime upcomingShowEndDate)
        {
            if (upcomingShowStartDate <= show.StartDate && upcomingShowEndDate >= show.EndDate)
            {
                return true;
            }
            else if (upcomingShowStartDate > show.StartDate)
            {
                if (upcomingShowStartDate <= show.EndDate)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (upcomingShowEndDate >= show.StartDate)
                {
                    return true;
                }
                return false;
            }
        }

        public bool isShowConflictedByTime(MovieShow show, TimeSpan upcomingShowStartTime, TimeSpan upcomingShowEndTime)
        {
            if(upcomingShowStartTime<=show.StartTime && upcomingShowEndTime >= show.EndTime)
            {
                return true;
            }
            else if(upcomingShowStartTime > show.StartTime)
            {
                if(upcomingShowStartTime< show.EndTime)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if(upcomingShowEndTime>show.StartTime)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> IsShowSlotAvailable(int ScreenId, DateTime StartDate, DateTime EndDate, TimeSpan StartTime, TimeSpan EndTime)
        {
            try
            {
                var conflictedShows = _appDBContext.Shows
                  .Where(s => s.ScreenId == ScreenId).AsEnumerable().Where(s=> isShowConflictedByDate(s, StartDate, EndDate) && isShowConflictedByTime(s, StartTime, EndTime)).ToList();
                if (conflictedShows.Any())
                {
                    return false;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        

        public async Task<MovieShow>AddMovieShow(MovieShow show)
        {
            try
            {
                var newShow = await _appDBContext.Shows.AddAsync(show);
                var movie= await _appDBContext.Movies.Where(m=> m.MovieId == show.MovieId).FirstOrDefaultAsync();
                movie.IsShowAdded= true;
                await _appDBContext.SaveChangesAsync();
                return newShow.Entity;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<List<MovieShow>?> GetAllAvailableShow(DateTime filterDate)
        {
            try
            {
                var shows= await _appDBContext.Shows.Where(s=> s.StartDate<=filterDate&& s.EndDate>=filterDate).Include(show=>show.MovieData).Include(show=>show.Tickets).ToListAsync();
                var availableShows= new List<MovieShow>();
                foreach (var show in shows)
                {
                    var allBookedSeatsInShow = 0;
                    foreach (var ticket in show.Tickets)
                    {
                        if (ticket.ShowDate == filterDate)
                        {
                            allBookedSeatsInShow += ticket.SeatCount;
                        }
                    }
                    if (allBookedSeatsInShow < show.TotalSeats)
                    {
                        var availableShowData = show;
                        availableShowData.SeatsRemaining = show.TotalSeats - allBookedSeatsInShow;
                        availableShows.Add(availableShowData);
                    }
                }
               return availableShows;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<MovieShow?>GetShowById(Guid showId)
        {
            try
            {
                return await _appDBContext.Shows.FirstOrDefaultAsync(s => s.ShowId == showId);
            }
            catch (Exception ex)
            {

                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
