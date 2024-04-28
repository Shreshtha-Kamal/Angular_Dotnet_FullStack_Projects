using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDAL.IRepository
{
    public interface ITicketRepository
    {
        public Task<int> GetBookedSeatCountForShowAtDate(Guid showId, DateTime bookingDate);
        public Task<Ticket> CreateTicket(Ticket ticketData);
        public Task<List<Ticket>?> GetAllUserTickets(string userId);
    }
}
