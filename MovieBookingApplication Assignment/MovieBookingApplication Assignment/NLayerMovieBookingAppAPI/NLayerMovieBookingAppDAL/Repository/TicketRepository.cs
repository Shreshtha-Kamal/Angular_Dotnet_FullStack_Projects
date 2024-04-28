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
    public class TicketRepository:ITicketRepository
    {
        private readonly AppDBContext _appDbContext;
        public TicketRepository(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        public async Task<int>GetBookedSeatCountForShowAtDate(Guid showId, DateTime bookingDate)
        {
            var tickets= await _appDbContext.Tickets.Where(t=>t.ShowId==showId && t.ShowDate.Date==bookingDate.Date).ToListAsync();
            int bookedSeatsCount = 0;
            foreach (var ticket in tickets)
            {
                bookedSeatsCount+= ticket.SeatCount;
            }
            return bookedSeatsCount;
        }

        public async Task<Ticket>CreateTicket(Ticket ticketData)
        {
            try
            {
                var newTicket = await _appDbContext.Tickets.AddAsync(ticketData);
                await _appDbContext.SaveChangesAsync();
                return newTicket.Entity;
            }
            catch (Exception ex)
            {

                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<List<Ticket>?>GetAllUserTickets(string userId)
        {
            try
            {
                var allTickets = await _appDbContext.Tickets.Where(t => t.UserId == userId).ToListAsync();
                return allTickets;
            }
            catch (Exception ex)
            {

                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
