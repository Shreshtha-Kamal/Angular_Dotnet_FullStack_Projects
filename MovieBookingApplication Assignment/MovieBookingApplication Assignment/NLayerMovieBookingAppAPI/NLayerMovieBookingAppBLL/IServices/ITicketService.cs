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
    public interface ITicketService
    {
        public Task<ServiceResult<Ticket?>> CreateTicket(TicketModel ticketData, string userId);
        public Task<ServiceResult<List<Ticket>?>> GetAllUserTickets(string userId);
    }
}
