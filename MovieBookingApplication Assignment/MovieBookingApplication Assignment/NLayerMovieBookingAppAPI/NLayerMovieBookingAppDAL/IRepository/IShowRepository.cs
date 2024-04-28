using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDAL.IRepository
{
    public interface IShowRepository
    {
        public Task<bool> IsShowSlotAvailable(int ScreenId, DateTime StartDate, DateTime EndDate, TimeSpan StartTime, TimeSpan EndTime);
        public Task<MovieShow> AddMovieShow(MovieShow show);
        public Task<List<MovieShow>?> GetAllAvailableShow(DateTime filterDate);
        public Task<MovieShow?> GetShowById(Guid showId);
    }
}
