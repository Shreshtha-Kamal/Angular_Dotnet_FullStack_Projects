using NLayerMovieBookingAppBLL.IServices;
using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDAL.IRepository;
using NLayerMovieBookingAppDAL.Repository;
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
    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IShowRepository _showRepository;
        public TicketService(ITicketRepository ticketRepository, IShowRepository showRepository)
        {
            _ticketRepository = ticketRepository;
            _showRepository = showRepository;
        }

        public async Task<ServiceResult<Ticket>>CreateTicket(TicketModel ticketData, string userId)
        {
            try
            {
                var show= await _showRepository.GetShowById(ticketData.ShowId);
                if (show == null)
                {
                    return new ServiceResult<Ticket>(HttpStatusCode.NotFound, new ValidationError(code: "ShowNotFound", description: "No Show exist with Given ShowId"));
                }
                var seatsAlreadyBooked= await _ticketRepository.GetBookedSeatCountForShowAtDate(ticketData.ShowId, ticketData.ShowDate);
                if (ticketData.SeatCount<= show.TotalSeats - seatsAlreadyBooked)
                {
                    var ticket= new Ticket()
                    {
                        TicketId= Guid.NewGuid(),
                        SeatCount= ticketData.SeatCount,
                        ShowDate= ticketData.ShowDate,
                        PricePerSeat= show.Price,
                        ShowId= ticketData.ShowId,
                        UserId= userId
                    };
                    var createdTicket= await _ticketRepository.CreateTicket(ticket)?? throw new ApiException(HttpStatusCode.InternalServerError, new Exception("Ticket Creation Failed")); ;
                    return new ServiceResult<Ticket>(HttpStatusCode.Created, createdTicket);
                }
                return new ServiceResult<Ticket>(HttpStatusCode.NotAcceptable, new ValidationError(code: "SeatsNotAvailable", description: "Required Number of Seats Are not Available"));
            }
            catch (ApiException) {
                throw;
            }
            catch (Exception ex)
            {

                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<ServiceResult<List<Ticket>?>>GetAllUserTickets(string userId)
        {
            try
            {
                var allTickets = await _ticketRepository.GetAllUserTickets(userId);
                if(allTickets == null)
                {
                    return new ServiceResult<List<Ticket>?>(HttpStatusCode.NotFound);
                }
                return new ServiceResult<List<Ticket>?>(HttpStatusCode.OK, allTickets);
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
